using IdentityServer4.Validation;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomAuthorizeRequestValidator : ICustomAuthorizeRequestValidator
    {
        public Task ValidateAsync(CustomAuthorizeRequestValidationContext context)
        {
            return Task.CompletedTask;
        }
    }

    public class Prompts
    {
        public const string Create = "create";
        public const string Google = "google";
    }
}
