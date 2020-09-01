using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
