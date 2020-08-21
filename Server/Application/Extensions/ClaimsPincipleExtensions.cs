using System;
using System.Linq;
using System.Security.Claims;

namespace Application.Extensions
{
    public static class ClaimsPincipleExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            if (user == null)
                return Guid.Empty;

            Guid.TryParse(user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid result);
            return result;
        }

        public static string Email(this ClaimsPrincipal user)
        {
            if (user == null)
                return string.Empty;

            return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
