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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserCreateModel model)
        {
            var result = await _userService.Register(model);
            return Ok(result);
        }

        [HttpGet("SearchEmail/{email}")]
        public async Task<IActionResult> SearchEmail(string email)
        {
            var result = await _userService.SearchEmail(email);
            return Ok(result);
        }

        [HttpPost("AddFriend/{userId}")]
        public async Task<IActionResult> AddFriend(Guid userId)
        {
            await _userService.AddFriend(userId);
            return NoContent();
        }

        [HttpGet("IsAnyUserEmail/{email}")]
        public async Task<IActionResult> IsAnyUserEmail(string email)
        {
            var result = await _userService.IsAnyUserEmail(email);
            return Ok(result);
        }

        [HttpGet("GetFriendRequests")]
        public async Task<IActionResult> GetFriendRequests()
        {
            var result = await _userService.GetFriendRequests();
            return Ok(result);
        }

        [HttpGet("GetFriends")]
        public async Task<IActionResult> GetFriends()
        {
            var result = await _userService.GetFriends();
            return Ok(result);
        }

        [HttpGet("AcceptFriend/{userId}")]
        public async Task<IActionResult> AcceptFriend(Guid userId)
        {
            await _userService.AcceptFriend(userId);
            return NoContent();
        }
    }
}