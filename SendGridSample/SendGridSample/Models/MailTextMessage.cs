using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendGridSample.Models
{
    public class MailTextMessage
    {
        public string Subject { get; set; }
        public string Contents { get; set; }
    }
}
