using Application.Extensions;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IChatService
    {
        Task Create(ChatCreateModel model);
        Task<PagingationModel<ChatModel>> Gets(ChatGetPagingationModel model);
        Task<ChatItemModel[]> GetChatList();
    }

    [ScopedDependency(ServiceType = typeof(IChatService))]
    public class ChatService : IChatService
    {
        private readonly HttpContext _httpContext;
        private readonly IGenericRepo<ChatEntity> _chatRepo;
        private readonly IGenericRepo<ChatFileEntity> _chatFileRepo;
        private readonly IGenericRepo<FriendShipEntity> _friendRepo;
        private readonly IUnitOfWork _unitOfWork;
        public ChatService(IHttpContextAccessor httpContextAccessor, IGenericRepo<ChatEntity> chatRepo,
            IGenericRepo<ChatFileEntity> chatFileRepo,
            IGenericRepo<FriendShipEntity> friendRepo,
            IUnitOfWork unitOfWork)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _chatRepo = chatRepo;
            _chatFileRepo = chatFileRepo;
            _friendRepo = friendRepo;
            _unitOfWork = unitOfWork;
        }

        public Task Create(ChatCreateModel model)
        {
            var fromUserId = _httpContext.User.Id();

            var entity = new ChatEntity
            {
                FromUserId = fromUserId,
                ToUserId = model.ToUserId,
                Message = model.Message
            };

            _chatRepo.Add(entity);

            if (model.FileIds != null && model.FileIds.Length > 0)
            {
                var chatFileEntities = model.FileIds.Select(x => new ChatFileEntity
                {
                    ChatId = entity.Id,
                    FileId = x
                }).ToArray();
                _chatFileRepo.AddRange(chatFileEntities);
            }

            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task<ChatItemModel[]> GetChatList()
        {
            var userId = _httpContext.User.Id();

            var cte = "select ROW_NUMBER() over( partition by FromUserId, ToUserId order by CreatedDatetime desc) as row_index, * from dbo.Chats";
            var entities = _chatRepo.GetFromSql($"with cte as ({cte}) select * from cte where row_index = 1 and FromUserId = '{userId}' or ToUserId = '{userId}' order by CreatedDatetime desc").ToList();

            var result = entities.Select(x => new ChatItemModel
            {
                UserId = x.FromUserId == userId ? x.ToUserId : x.FromUserId,
                UserEmail = x.FromUserId == userId ? x.ToUser.Email : x.FromUser.Email,
                Name = x.FromUserId == userId ? x.ToUser.Name : x.FromUser.Name,
                Avatar = x.FromUserId == userId ? x.ToUser.Avatar.File.Url : x.FromUser.Avatar.File.Url,
                Message = x.Message,
                FileModels = x.ChatFiles.Select(file => file.MapTo<FileModel>()).ToArray()
            }).DistinctBy(x => x.UserId).ToArray();

            return Task.FromResult(result);
        }

        public Task<PagingationModel<ChatModel>> Gets(ChatGetPagingationModel model)
        {
            var currentUserId = _httpContext.User.Id();

            var queryable = _chatRepo.Get(x => x.FromUserId == currentUserId && x.ToUserId == model.UserId || x.FromUserId == model.UserId && x.ToUserId == currentUserId)
                .OrderByDescending(x => x.CreatedDateTime)
                .QueryTo<ChatModel>();

            var result = PagingationModel<ChatModel>.Create(queryable, model.PageIndex, model.PageSize);
            return Task.FromResult(result);
        }
    }
}
