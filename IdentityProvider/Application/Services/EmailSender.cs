using Elect.DI.Attributes;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    [ScopedDependency(ServiceType = typeof(IEmailSender))]
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
