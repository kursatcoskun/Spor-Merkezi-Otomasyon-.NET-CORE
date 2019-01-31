using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Models
{
    public class satis
    {
        public satis()
        {
            SatisTarihi = DateTime.Now;
        }
        public int Id { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyati { get; set; }
        public int ToplamUrunAdedi { get; set; }
        public double ToplamTutar { get; set; }
        public DateTime SatisTarihi { get; set; }

    }
}
