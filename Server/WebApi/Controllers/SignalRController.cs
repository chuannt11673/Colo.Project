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
        public SignalRController(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        [HttpPost("SendUser/{userId}")]
        public async Task<IActionResult> SendUser([FromBody] SignalRModel model, string userId)
        {
            await _signalRService.SendMessage(model, userId);
            return NoContent();
        }
    }
}