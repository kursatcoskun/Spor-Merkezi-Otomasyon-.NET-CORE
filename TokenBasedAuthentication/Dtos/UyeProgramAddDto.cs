using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamSporMerkezi.API.Dtos
{
    public class UyeProgramAddDto
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public string AntrenmanAdi { get; set; }
        public int SetSayisi { get; set; }
        public int TekrarSayisi { get; set; }
    }
}
