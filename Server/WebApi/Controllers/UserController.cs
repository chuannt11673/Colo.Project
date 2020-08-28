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
        /// Get User Info
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var result = await _userService.GetUserInfo();
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

        /// <summary>
        /// Update User Avatar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateUserProfileImage")]
        public async Task<IActionResult> UpdateUserProfileImage([FromBody] UserUpdateProfileModel model)
        {
            var result = await _userService.UpdateUserFile(model);
            return Ok(result);
        }

        /// <summary>
        /// Update User Cover
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateUserCover")]
        public async Task<IActionResult> UpdateUserCover([FromBody] UserUpdateCoverModel model)
        {
            var result = await _userService.UpdateUserFile(model);
            return Ok(result);
        }

        /// <summary>
        /// Update User Info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserUpdateModel model)
        {
            await _userService.UpdateUserInfo(model);
            return NoContent();
        }

        /// <summary>
        /// Suggest Friends
        /// </summary>
        /// <returns></returns>
        [HttpGet("SuggestFriends")]
        public async Task<IActionResult> SuggestFriends()
        {
            var result = await _userService.SuggestFriends();
            return Ok(result);
        }
    }
}