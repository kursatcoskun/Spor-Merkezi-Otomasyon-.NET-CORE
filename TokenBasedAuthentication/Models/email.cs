using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Models
{
    public class email
    {
       
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string EmailSubject { get; set; }
        public string Message { get; set; }
    }
}
