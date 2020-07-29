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
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromBody] FileCreateModel model)
        {
            return Ok(await _fileService.Upload(model));
        }

        [HttpPost("UploadMultiple")]
        public async Task<IActionResult> UploadMultiple([FromBody] FileCreateModel[] models)
        {
            return Ok(await _fileService.Upload(models));
        }
    }
}