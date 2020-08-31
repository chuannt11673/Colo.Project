using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        private readonly ISignalRService _signalRService;
        private readonly IChatService _chatService;
        public SignalRController(ISignalRService signalRService, IChatService chatService)
        {
            _signalRService = signalRService;
            _chatService = chatService;
        }

        /// <summary>
        /// Send message to user usign signalR
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("SendUser/{userId}")]
        public async Task<IActionResult> SendUser([FromBody] SignalRModel model, string userId)
        {
            await _chatService.Create(new ChatCreateModel { ToUserId = new Guid(userId), Message = model.Message, FileIds = model.FileModels.Select(x => x.Id).ToArray() });
            await _signalRService.SendMessage(model, userId);
            return Ok();
        }

        /// <summary>
        /// Send notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationModel model)
        {
            await _signalRService.SendNotification(model);
            return Ok();
        }

        /// <summary>
        /// Get notifications
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNotifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var result = await _signalRService.GetNotifications();
            return Ok(result);
        }
    }
}