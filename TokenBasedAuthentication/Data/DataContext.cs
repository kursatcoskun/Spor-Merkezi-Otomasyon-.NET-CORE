using AdamSporMerkezi.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Uye> uyes { get; set; }
        public DbSet<UyeOdeme> uyeOdemes { get; set; }
        public DbSet<UyeProgram> uyePrograms { get; set; }
        public DbSet<UyeVucutInfo> uyeVucutInfos { get; set; }
        public DbSet<Antrenman> antrenmen { get; set; }
        public DbSet<Urun> uruns { get; set; }
        public DbSet<Gelir> gelirs { get; set; }
        public DbSet<Gider> giders { get; set; }
        public DbSet<Stok> stoks { get; set; }
        public DbSet<satis> satislar { get; set; }
        public DbSet<UyeAktiflik> UyeAktiflikler { get; set; }



    }
}
