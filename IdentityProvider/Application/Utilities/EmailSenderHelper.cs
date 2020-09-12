using Application.Models;
using Elect.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class EmailTemplate
    {
        public string Register { get; set; }
    }

    public interface IEmailSenderHelper
    {
        Task<EmailModel> GetRegisterUserEmailMessage(string userId);
    }

    [ScopedDependency(ServiceType = typeof(IEmailSenderHelper))]
    public class EmailSenderHelper : IEmailSenderHelper
    {
        private readonly string _rootPathUri;
        private readonly EmailTemplate _emailTemplate;
        public EmailSenderHelper(IHttpContextAccessor httpContextAccessor,
            IOptions<EmailTemplate> options)
        {
            _rootPathUri = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
            _emailTemplate = options.Value;
        }

        public async Task<EmailModel> GetRegisterUserEmailMessage(string userId)
        {
            var subject = "Register Colo";
            var url = $"{_rootPathUri}/Account/Confirm?userId={userId}";
            var htmlMessage = _emailTemplate.Register.Replace("<link>", url);

            var result = new EmailModel() {
                Subject = subject,
                HtmlMessage = htmlMessage
            };

            return await Task.FromResult(result);
        }
    }
}
