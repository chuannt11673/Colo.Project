using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PostCreateModel model)
        {
            var result = await _postService.Create(model);
            return Ok(result);
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Gets")]
        public async Task<IActionResult> Gets([FromBody] PagingationRequestModel model)
        {
            var result = await _postService.Gets(model);
            return Ok(result);
        }

        /// <summary>
        /// Like
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("Like/{postId}")]
        public async Task<IActionResult> Like(Guid postId)
        {
            await _postService.Like(postId);
            return Ok();
        }

        /// <summary>
        /// Comment into a post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Comment")]
        public async Task<IActionResult> Comment([FromBody] PostCommentCreateModel model)
        {
            var result = await _postService.Comment(model);
            return Ok(result);
        }

        /// <summary>
        /// Get comments
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("GetComments/{postId}")]
        public async Task<IActionResult> GetComments(Guid postId)
        {
            var result = await _postService.GetComments(postId);
            return Ok(result);
        }

        /// <summary>
        /// Get posts by user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetPostsByUser/{userId}")]
        public async Task<IActionResult> GetPostsByUser(Guid userId, [FromBody] PagingationRequestModel model)
        {
            var result = await _postService.Gets(userId, model);
            return Ok(result);
        }
    }
}
