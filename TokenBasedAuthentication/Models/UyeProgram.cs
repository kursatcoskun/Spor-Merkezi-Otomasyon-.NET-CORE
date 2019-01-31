using System.Collections.Generic;

namespace TokenBasedAuthentication.Models
{
    public class UyeProgram

        
    {
        public UyeProgram()
        {
            antrenmans = new List<Antrenman>();
        }
        public int Id { get; set; }
        public int UyeId { get; set; }
      

        public Uye uye { get; set; }
        public List<Antrenman> antrenmans { get; set; }

    }
}