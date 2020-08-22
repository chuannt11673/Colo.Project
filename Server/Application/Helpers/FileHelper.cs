using Application.Extensions;
using Elect.DI.Attributes;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public interface IFileHelper
    {
        Task<FileHelperModel> Resize(string base64);
    }

    [ScopedDependency(ServiceType = typeof(IFileHelper))]
    public class FileHelper : IFileHelper
    {
        private readonly int _width = 500;
        private readonly string _rootPath = Directory.GetCurrentDirectory() + @"\wwwroot";
        private readonly HttpContext _httpContext;

        public FileHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Task<FileHelperModel> Resize(string base64)
        {
            var returnModel = new FileHelperModel() {
                FileName = $"{Path.GetRandomFileName().Split(".")[0]}-{DateTimeOffset.UtcNow.Ticks}"
            };

            var userEmail = _httpContext.User.Email();

            using (var input = new MemoryStream(Convert.FromBase64String(base64)))
            {
                using (var image = Image.Load(input))
                {
                    var height = (int)Math.Round((decimal)(_width * image.Height / image.Width));
                    var savedPath = GetSavedPath(userEmail, returnModel.FileName);

                    image.Mutate(x => x.Resize(_width, height));
                    image.Save(savedPath, new JpegEncoder());
                    returnModel.Url = savedPath.Replace(_rootPath, "");
                }
            }

            return Task.FromResult(returnModel);
        }

        private string GetSavedPath(string userEmail, string fileName)
        {
            var directory = Path.Combine(_rootPath, $@"images\{userEmail}");
            Directory.CreateDirectory(directory);
            return $@"{directory}\{fileName}.jpg";
        }
    }

    public class FileHelperModel
    {
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
