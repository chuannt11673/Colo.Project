using System;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
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
    }
}