using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridSample.Models;

namespace SendGridSample.Services
{
    public class SendGridSmtpClient : ISmtpClient
    {
        private readonly ISendGridClient _sendGridClient;
        public SendGridSmtpClient(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendMail(MailAddress fromAddress, IEnumerable<MailAddress> toAddress, MailTextMessage textMessage)
        {
            var message = new SendGridMessage
            {
                From = new EmailAddress(fromAddress.Address, fromAddress.Name),
                Subject = textMessage.Subject,
                PlainTextContent = textMessage.Contents
            };
            message.AddTos(toAddress.Select(a => new EmailAddress(a.Address, a.Name)).ToList());
            await _sendGridClient.SendEmailAsync(message);
        }
    }
}
