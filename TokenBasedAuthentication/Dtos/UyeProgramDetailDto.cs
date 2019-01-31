using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenBasedAuthentication.Models;

namespace AdamSporMerkezi.API.Dtos
{
    public class UyeProgramDetailDto
    {
        public UyeProgramDetailDto()
          {

            antrenmans = new List<Antrenman>();
        }
    public int Id { get; set; }
    public int UyeId { get; set; }


    public Uye uye { get; set; }
    public List<Antrenman> antrenmans { get; set; }
}
}
