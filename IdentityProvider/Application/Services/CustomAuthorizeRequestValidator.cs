using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomAuthorizeRequestValidator : ICustomAuthorizeRequestValidator
    {
        private readonly HttpContext HttpContext;
        public CustomAuthorizeRequestValidator(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
        }

        public Task ValidateAsync(CustomAuthorizeRequestValidationContext context)
        {
            var request = context.Result.ValidatedRequest;
            var promt = request.Raw["prompt"];
            
            if (HttpContext.Request.Path.StartsWithSegments("/Account/Login"))
            {
                if (promt == Prompts.Create)
                    HttpContext.Response.Redirect("/Account/Register" + HttpContext.Request.QueryString);
                else if (promt == Prompts.Google)
                    HttpContext.Response.Redirect("/External/Challenge" + HttpContext.Request.QueryString + "&provider=Google");
            }

            return Task.CompletedTask;
        }
    }

    public class Prompts
    {
        public const string Create = "create";
        public const string Google = "google";
    }
}
