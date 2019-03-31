using System.Collections.Generic;
using System.Threading.Tasks;
using SendGridSample.Models;

namespace SendGridSample.Services
{
    public interface ISmtpClient
    {
        Task SendMail(MailAddress fromAddress, IEnumerable<MailAddress> toAddress, MailTextMessage textMessage);
    }
}
