using Application.Extensions;
using Application.Hubs;
using Application.Models;
using Core.Entities;
using Elect.Core.LinqUtils;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISignalRService
    {
        Task SendMessage(SignalRModel model, string userId);
        Task SendNotification(NotificationModel model);
        Task<IEnumerable<NotificationModel>> GetNotifications();
    }

    [ScopedDependency(ServiceType = typeof(ISignalRService))]
    public class SignalRService : ISignalRService
    {
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly HttpContext _httpContext;
        private readonly IGenericRepo<NotificationEntity> _notiRepo;
        private readonly IUnitOfWork _unitOfWork;

        public SignalRService(IHubContext<ChatHub> chatHub,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepo<NotificationEntity> notiRepo,
            IUnitOfWork unitOfWork)
        {
            _chatHub = chatHub;
            _httpContext = httpContextAccessor.HttpContext;
            _notiRepo = notiRepo;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<NotificationModel>> GetNotifications()
        {
            var userId = _httpContext.User.Id();

            var notificationModels = _notiRepo.Get(x => x.ForAllUsers || x.UserId == userId).QueryTo<NotificationModel>().AsEnumerable();

            return Task.FromResult(notificationModels);
        }

        public async Task SendMessage(SignalRModel model, string userId)
        {
            await _chatHub.Clients.User(userId).SendAsync("Message", JsonConvert.SerializeObject(new
            {
                UserId = _httpContext.User.Id(),
                UserEmail = _httpContext.User.Email(),
                model.Message,
                model.FileModels
            }));
        }

        public async Task SendNotification(NotificationModel model)
        {
            var entity = model.MapTo<NotificationEntity>();

            _notiRepo.Add(entity);
            _unitOfWork.Commit();

            await _chatHub.Clients.User(model.UserId.ToString()).SendAsync("Notification", model.ToString());
        }
    }
}
