using Elect.DI.Attributes;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    [ScopedDependency(ServiceType = typeof(IEmailSender))]
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> options)
        {
            _smtpSettings = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var host = _smtpSettings.Server;
            var port = _smtpSettings.Port;
            var fromEmail = _smtpSettings.FromEmail;

            using var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(fromEmail, "@colo123456"),
                EnableSsl = true
            };

            var from = new MailAddress(fromEmail, "Colo");
            var to = new MailAddress(email);

            var mailMessage = new MailMessage(from, to)
            {
                Body = htmlMessage,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Subject = subject,
                SubjectEncoding = Encoding.UTF8
            };

            await client.SendMailAsync(mailMessage);
        }
    }

    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string FromEmail { get; set; }
    }
}
