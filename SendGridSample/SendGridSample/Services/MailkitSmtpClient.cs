using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SendGridSample.Models;

namespace SendGridSample.Services
{
    public class MailkitSmtpClient: ISmtpClient
    {
        private readonly SmtpConfig _config;

        public MailkitSmtpClient(IOptions<SmtpConfig> config)
        {
            _config = config.Value;
        }

        private MailboxAddress ConvertToMailboxAddress(MailAddress address)
        {
            return new MailboxAddress(Encoding.UTF8, address.Name, address.Address);
        }
        public async Task SendMail(MailAddress fromAddress, IEnumerable<MailAddress> toAddress, MailTextMessage textMessage)
        {
            using (var mailKit = new MailKit.Net.Smtp.SmtpClient())
            {
                var message = new MimeMessage();
                message.From.Add(ConvertToMailboxAddress(fromAddress));
                message.To.AddRange(toAddress.Select(ConvertToMailboxAddress).ToList());
                message.Subject = textMessage.Subject;
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = textMessage.Contents
                };

                await mailKit.ConnectAsync(_config.Host, _config.Port, SecureSocketOptions.StartTls);
                if (_config.UseAuthenticate)
                {
                    await mailKit.AuthenticateAsync(Encoding.UTF8, _config.User, _config.Password);
                }
                await mailKit.SendAsync(FormatOptions.Default, message);
                mailKit.Disconnect(true);
            }
        }
    }
}
