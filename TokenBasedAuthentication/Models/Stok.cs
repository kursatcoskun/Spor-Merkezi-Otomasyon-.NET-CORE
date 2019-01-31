using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Models
{
    public class Stok
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int StokMiktari { get; set; }

        public Urun urun { get; set; }

    }
}
