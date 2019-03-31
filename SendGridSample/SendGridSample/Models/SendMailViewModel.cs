using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendGridSample.Models
{
    public class SendMailViewModel
    {
        public MailAddress FromAddress { get; set; }
        public MailAddress ToAddress { get; set; }
        public MailTextMessage Message { get; set; }
    }
}
