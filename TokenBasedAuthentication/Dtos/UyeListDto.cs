using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenBasedAuthentication.Dtos
{
    public class UyeListDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
