using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings mEmailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            mEmailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            var tSendGridClient = new SendGridClient(mEmailSettings.ApiKey);
            var tTo = new EmailAddress(email.To);
            var tFrom = new EmailAddress
            {
                Email = mEmailSettings.FromAddress,
                Name = mEmailSettings.FromName
            };

            var tMessage = MailHelper.CreateSingleEmail(tFrom, tTo, email.Subject, email.Body, email.Body);
            var tResponse = await tSendGridClient.SendEmailAsync(tMessage);

            return tResponse.StatusCode == System.Net.HttpStatusCode.OK || 
                   tResponse.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
