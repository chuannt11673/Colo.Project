using System;
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

        [HttpPost("SendUser/{userId}")]
        public async Task<IActionResult> SendUser([FromBody] SignalRModel model, string userId)
        {
            await _chatService.Create(new ChatCreateModel { ToUserId = new Guid(userId), Message = model.Message });
            await _signalRService.SendMessage(model, userId);
            return NoContent();
        }
    }
}