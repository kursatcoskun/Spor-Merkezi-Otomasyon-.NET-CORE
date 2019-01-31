using System;
using System.Collections.Generic;

namespace TokenBasedAuthentication.Models
{
    public class UyeOdeme
    {

      
       
        public int Id { get; set; }
        public int UyeId { get; set; }
        public string UyelikTipi { get; set; }
        public int UyelikSuresi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int KayitTutari { get; set; }
        public Uye uyes { get; set; }
    }

}