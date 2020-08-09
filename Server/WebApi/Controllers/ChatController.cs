using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Get chat history
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Gets")]
        public async Task<IActionResult> Gets([FromBody] ChatGetPagingationModel model)
        {
            return Ok(await _chatService.Gets(model));
        }

        /// <summary>
        /// Get Chat List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetChatList")]
        public async Task<IActionResult> GetChatList()
        {
            return Ok(await _chatService.GetChatList());
        }
    }
}