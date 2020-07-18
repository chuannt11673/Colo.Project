using Application.Extensions;
using Application.Hubs;
using Application.Models;
using Elect.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISignalRService
    {
        Task SendMessage(SignalRModel model, string userId);
    }

    [ScopedDependency(ServiceType = typeof(ISignalRService))]
    public class SignalRService : ISignalRService
    {
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly HttpContext _httpContext;

        public SignalRService(IHubContext<ChatHub> chatHub, IHttpContextAccessor httpContextAccessor)
        {
            _chatHub = chatHub;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task SendMessage(SignalRModel model, string userId)
        {
            await _chatHub.Clients.User(userId).SendAsync("SendMessage", JsonConvert.SerializeObject(new {
                UserId = _httpContext.UserId(),
                UserEmail = _httpContext.UserEmail(),
                model.Message
            }));
        }
    }
}
