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

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserCreateModel model)
        {
            var result = await _userService.Register(model);
            return Ok(result);
        }

        /// <summary>
        /// Search user using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("SearchEmail/{email}")]
        public async Task<IActionResult> SearchEmail(string email)
        {
            var result = await _userService.SearchEmail(email);
            return Ok(result);
        }

        /// <summary>
        /// Add friend for a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("AddFriend/{userId}")]
        public async Task<IActionResult> AddFriend(Guid userId)
        {
            await _userService.AddFriend(userId);
            return NoContent();
        }

        /// <summary>
        /// Check if user is existed or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("IsAnyUserEmail/{email}")]
        public async Task<IActionResult> IsAnyUserEmail(string email)
        {
            var result = await _userService.IsAnyUserEmail(email);
            return Ok(result);
        }

        /// <summary>
        /// Get friend requests for user
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFriendRequests")]
        public async Task<IActionResult> GetFriendRequests()
        {
            var result = await _userService.GetFriendRequests();
            return Ok(result);
        }

        /// <summary>
        /// Get friends of user
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFriends")]
        public async Task<IActionResult> GetFriends()
        {
            var result = await _userService.GetFriends();
            return Ok(result);
        }

        /// <summary>
        /// Accept friend request
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("AcceptFriend/{userId}")]
        public async Task<IActionResult> AcceptFriend(Guid userId)
        {
            await _userService.AcceptFriend(userId);
            return NoContent();
        }

        [HttpPost("UpdateUserProfileImage")]
        public async Task<IActionResult> UpdateUserProfileImage([FromBody] UserUpdateProfileModel model)
        {
            var result = await _userService.UpdateUserFile(model);
            return Ok(result);
        }

        [HttpPost("UpdateUserCover")]
        public async Task<IActionResult> UpdateUserCover([FromBody] UserUpdateCoverModel model)
        {
            var result = await _userService.UpdateUserFile(model);
            return Ok(result);
        }


    }
}