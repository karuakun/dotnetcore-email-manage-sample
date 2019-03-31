using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendGridSample.Models
{
    public class SmtpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseAuthenticate { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
