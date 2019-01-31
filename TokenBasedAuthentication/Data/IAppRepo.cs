using AdamSporMerkezi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Data
{
    public interface IAppRepo
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveAll();
        void DeleteById(int id);
        void DeleteUrunById(int id);
        void DeleteGiderById(int id);
        void DeleteVucutBilgiById(int id);
        void DeleteAntrenmanById(int id);
        void DeleteOdemeById(int id);
        void DeleteSatisById(int id);
       


        #region List Return Methods


        List<Uye> GetUyeler(); 
        List <UyeVucutInfo> GetVucutInfoById(int uyeId);
        //To-Do
        List<UyeOdeme> GetUyeOdemeById(int id);
        //List<Gelir> GetAllGelirs();
        List<Gider> GetAllGiders();
        List<Urun> GetAllUruns();
        List<UyeOdeme> GetAllOdemes();
        List<satis> GetAllSatis();
        List<UyeAktiflik> GetUyeAktiflikById(int id);
        #endregion

        #region Class Return Methods


        Uye GetUyeById(int id);
       
        UyeProgram GetProgramById(int uyeId);
        //To-Do
        Urun GetUrunById(int urunId);

        #endregion


    }
}
