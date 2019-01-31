using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenBasedAuthentication.Models;

namespace AdamSporMerkezi.API.Models
{
    public class Gelir
    {
        public Gelir()
        {
            tarih = DateTime.Now;
            uruns = new List<Urun>();
        }

        public int Id { get; set; }
        public string GelirAdi { get; set; }
        public double GelirMiktari { get; set; }
        public DateTime tarih { get; set; }
        public List<Urun> uruns { get; set; }
        public UyeOdeme uyeOdeme { get; set; }

    }
}
