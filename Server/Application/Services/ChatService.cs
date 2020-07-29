using Application.Extensions;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
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
    }

    [ScopedDependency(ServiceType = typeof(IChatService))]
    public class ChatService : IChatService
    {
        private readonly HttpContext _httpContext;
        private readonly IGenericRepo<ChatEntity> _chatRepo;
        private readonly IGenericRepo<ChatFileEntity> _chatFileRepo;
        private readonly IUnitOfWork _unitOfWork;
        public ChatService(IHttpContextAccessor httpContextAccessor, IGenericRepo<ChatEntity> chatRepo,
            IGenericRepo<ChatFileEntity> chatFileRepo,
            IUnitOfWork unitOfWork)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _chatRepo = chatRepo;
            _chatFileRepo = chatFileRepo;
            _unitOfWork = unitOfWork;
        }

        public Task Create(ChatCreateModel model)
        {
            var fromUserId = _httpContext.UserId();
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
                _chatFileRepo.Add(chatFileEntities);
            }

            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task<PagingationModel<ChatModel>> Gets(ChatGetPagingationModel model)
        {
            var currentUserId = _httpContext.UserId();

            var queryable = _chatRepo.Get(x => x.FromUserId == currentUserId && x.ToUserId == model.UserId || x.FromUserId == model.UserId && x.ToUserId == currentUserId)
                .OrderByDescending(x => x.CreatedDateTime)
                .QueryTo<ChatModel>();

            var result = PagingationModel<ChatModel>.Create(queryable, model.PageIndex, model.PageSize);
            return Task.FromResult(result);
        }
    }
}
