using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenBasedAuthentication.Models;
using Microsoft.EntityFrameworkCore;
using AdamSporMerkezi.API.Models;

namespace TokenBasedAuthentication.Data
{
    public class AppRepo : IAppRepo
    {
        DataContext _context;

        public AppRepo(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var uye = _context.uyes.FirstOrDefault(c => c.Id == id);
            _context.Remove(uye);

        }

        public void DeleteUrunById(int id)
        {
            var urun = _context.uruns.FirstOrDefault(u => u.Id == id);
            _context.Remove(urun);
        }

        public void DeleteGiderById(int id)
        {
            var gider = _context.giders.FirstOrDefault(g => g.Id == id);
            _context.Remove(gider);
        }


        public void DeleteVucutBilgiById(int id)
        {
            var vucutbilgi = _context.uyeVucutInfos.FirstOrDefault(v => v.Id == id);
            _context.Remove(vucutbilgi);
        }

        public void DeleteAntrenmanById(int id)
        {
            var antrenman = _context.antrenmen.FirstOrDefault(a => a.Id == id);
            _context.Remove(antrenman);
        }

        public void DeleteOdemeById(int id)
        {
            var odeme = _context.uyeOdemes.FirstOrDefault(x => x.Id == id);
            _context.Remove(odeme);
        }

        public void DeleteSatisById(int id)
        {
            var satis = _context.satislar.FirstOrDefault(s => s.Id == id);
            _context.Remove(satis);
        }


        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        #region Class Return Methods

        public Uye GetUyeById(int id)
        {
            var uye = _context.uyes.Include(c => c.UyeVucutInfos).Include(c => c.uyeProgram).Include(c => c.uyeOdemes).FirstOrDefault(c => c.Id == id);
            return uye;
        }

        public UyeProgram GetProgramById(int uyeId)
        {
            var program = _context.uyePrograms.Include(z=>z.antrenmans).FirstOrDefault(x => x.UyeId == uyeId);
            return program;
        }

        public Urun GetUrunById(int urunId)
        {
            var urun = _context.uruns.FirstOrDefault(x => x.Id == urunId);
            return urun;
        }

     

        #endregion

        #region List Return Methods
        public List <UyeVucutInfo> GetVucutInfoById(int uyeId)
        {
            var vucutbilgiler = _context.uyeVucutInfos.Where(x => x.UyeId == uyeId).ToList();
            return vucutbilgiler;
        }
        public List<Uye> GetUyeler()
        {
            var uyeler = _context.uyes.Include(c => c.UyeVucutInfos).ToList();
            return uyeler;
        }

        public List<Urun> GetAllUruns()
        {
            var urunler = _context.uruns.ToList();
            return urunler;
        }

        public List<Gider> GetAllGiders()
        {
            var giderler = _context.giders.ToList();
            return giderler;
        }

        public List<UyeOdeme> GetAllOdemes()
        {
            var odemeler = _context.uyeOdemes.ToList();
            return odemeler;
        }

        public List<UyeOdeme> GetUyeOdemeById(int id)
        {
            var odemeler = _context.uyeOdemes.Where(o => o.UyeId == id).ToList();
            return odemeler;
        }

        public List<satis> GetAllSatis()
        {
            var satislar = _context.satislar.ToList();
            return satislar;
        }



        public List<UyeAktiflik> GetUyeAktiflikById(int id)
        {
            var uyeAktif = _context.UyeAktiflikler.Where(a => a.UyeId == id).ToList();
            return uyeAktif;
        }


        #endregion


    }
}
