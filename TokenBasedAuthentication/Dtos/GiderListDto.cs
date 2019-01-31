using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Dtos
{
    public class GiderListDto
    {

        public GiderListDto()
        {
            tarih = DateTime.Now;
        }

        public int Id { get; set; }
        public string GiderAciklama { get; set; }
        public double GiderMiktari { get; set; }
        public DateTime tarih { get; set; }
    }
}
