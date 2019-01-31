using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenBasedAuthentication.Models
{
    public class Uye
    {
        public Uye()
        {
            UyeVucutInfos = new List<UyeVucutInfo>();
            uyeOdemes = new List<UyeOdeme>();
        }
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public UyeProgram uyeProgram { get; set; }
        public List<UyeVucutInfo> UyeVucutInfos { get; set; }
        public List<UyeOdeme> uyeOdemes { get; set; }

    }
}
