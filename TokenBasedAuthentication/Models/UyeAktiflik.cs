using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Models
{
    public class UyeAktiflik
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public Boolean AktiflikDurumu { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int KalanGun { get; set; }
    }
}
