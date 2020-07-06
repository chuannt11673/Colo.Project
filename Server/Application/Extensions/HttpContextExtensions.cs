using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace Application.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid UserId(this HttpContext httpContext) => Guid.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        public static string UserEmail(this HttpContext httpContext) => httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
    }
}
