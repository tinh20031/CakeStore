using CakeStore.Business.Configurations;
using CakeStore.Business.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly GmailSetting _gmail;

        public EmailService(IOptions<GmailSetting> options)
        {
            _gmail = options.Value;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient(_gmail.Host, _gmail.Port)
            {
                Credentials = new NetworkCredential(_gmail.Email, _gmail.Password),
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_gmail.Email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);
            await client.SendMailAsync(mailMessage);
        }

    }
}
