using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderingApplication.Contracts.Infrastructure;
using OrderingApplication.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OrderingInfrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var form = new EmailAddress
            {
                Name = _emailSettings.FromName,
                Email = _emailSettings.FromAddress
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(form, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted
                || response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                return true;
            }

            _logger.LogInformation("Email Send");

            return false;
        }

    }
}
