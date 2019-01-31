using System;

namespace TokenBasedAuthentication.Models
{
    public class UyeVucutInfo
    {


        public UyeVucutInfo()
        {
            eklemeTarihi = DateTime.Now;
        }

        public int Id { get; set; }
        public int UyeId { get; set; }
        public double Boy { get; set; }
        public double Kilo { get; set; }
        public double SolKol { get; set; }
        public double SagKol { get; set; }
        public double Omuz { get; set; }
        public double Gogus { get; set; }
        public double Bel { get; set; }
        public double SolBacak { get; set; }
        public double SagBacak { get; set; }
        public DateTime eklemeTarihi { get; set; }

        public Uye uye { get; set; }
    }
}