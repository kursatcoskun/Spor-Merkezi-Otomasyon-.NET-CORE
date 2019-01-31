using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyati { get; set; }
        public int ToplamUrunAdedi { get; set; }

    }
}
