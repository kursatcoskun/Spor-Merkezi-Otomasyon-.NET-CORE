using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamSporMerkezi.API.Dtos;
using AdamSporMerkezi.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthentication.Data;
using TokenBasedAuthentication.Dtos;
using TokenBasedAuthentication.Models;

using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace TokenBasedAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyelerController : ControllerBase
    {

        #region Properties

        IAppRepo _Apprepo;
        private IMapper _mapper;
        private DataContext _context;
        #endregion


        #region Constructor

        public UyelerController(IAppRepo appRepo, IMapper mapper,DataContext context)
        {
            _Apprepo = appRepo;
            _mapper = mapper;
            _context = context;
        }

        #endregion


        #region GetRequests

        [HttpGet]
        public ActionResult getUyeler()
        {
            var uyeler = _Apprepo.GetUyeler();
            var uyelerReturn = _mapper.Map<List<UyeListDto>>(uyeler);
            return Ok(uyeler);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetUyeById(int id)
        {
            var uye = _Apprepo.GetUyeById(id);
            var uyeReturn = _mapper.Map<UyeDetailDto>(uye);
            return Ok(uyeReturn);
        }

        [HttpGet]
        [Route("uyeProgram")]
        public ActionResult GetProgramByUyeId(int id)
        {
            var program = _Apprepo.GetProgramById(id);
            var programReturn = _mapper.Map<UyeProgramDetailDto>(program);

            return Ok(programReturn);
        }

        [HttpGet]
        [Route("vucutbilgi")]
        public ActionResult GetVucutInfoById(int id)
        {
            var vucuts = _Apprepo.GetVucutInfoById(id);
            var returnvucutbilgi = _mapper.Map<List<UyeVucutBilgiDetailDto>>(vucuts);
            return Ok(returnvucutbilgi);
        }

        [HttpGet]
        [Route("urunlerigoster")]
        public ActionResult getUrunler()
        {
            var urunler = _Apprepo.GetAllUruns();
            var ReturnUrunler = _mapper.Map<List<UrunForListDto>>(urunler);
            return Ok(ReturnUrunler);
        }

        [HttpGet]
        [Route("urunlerbyid")]
        public ActionResult getUrunById(int id)
        {
            var urun = _Apprepo.GetUrunById(id);
            return Ok(urun);
        }

        [HttpGet]
        [Route("GiderleriGoster")]
        public ActionResult getGiderler()
        {
            var giderler = _Apprepo.GetAllGiders();
            var returnGiderler = _mapper.Map<List<GiderListDto>>(giderler);
            return Ok(returnGiderler);
        }
        [HttpGet]
        [Route("GiderlerTutarlari")]
        public ActionResult getGiderTutarlari()
        {
            var giderler = _Apprepo.GetAllGiders();
            double[] gider = new double[giderler.Count];
            double toplam = new double();
            for (int i = 0; i < giderler.Count; i++)
            {
                gider[i] = giderler[i].GiderMiktari;
            }
            for (int i = 0; i < gider.Length; i++)
            {
                toplam += gider[i];
            }

            return Ok(toplam);
        }
        [HttpGet]
        [Route("OdemeleriGor")]
        public ActionResult getAllOdemes()
        {
            var odemeler = _Apprepo.GetAllOdemes();
            double[] odeme = new double[odemeler.Count];
            for (int i = 0; i < odemeler.Count; i++)
            {
                odeme[i] = odemeler[i].KayitTutari;
            }

            return Ok(odeme);
        }
        [HttpGet]
        [Route("odemeTarihleri")]
        public ActionResult GetOdemeTarihi()
        {
            var odemeler = _Apprepo.GetAllOdemes();
            DateTime[] kayitTarih = new DateTime[odemeler.Count];
            for (int i = 0; i < odemeler.Count; i++)
            {
                kayitTarih[i] = odemeler[i].KayitTarihi;
            }

            return Ok(kayitTarih);
        }

        [HttpGet]
        [Route("odemebyId")]
        public ActionResult getAllOdemes(int id)
        {
            var odemeler = _Apprepo.GetUyeOdemeById(id);
            return Ok(odemeler);
        }
        [HttpGet]
        [Route("satislar")]
        public ActionResult getSatislar(int id)
        {
            var satislar = _Apprepo.GetAllSatis();
            return Ok(satislar);
        }
        //Without Entity Framework Accessing Database
        [HttpGet]
        [Route("UyeDurumlari")]
        public ActionResult getDurum()
        {
            List<String> columnData = new List<String>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT DateDiff(DAY,dbo.uyeOdemes.KayitTarihi,GETDATE()) as Day,DateDiff(MONTH,dbo.uyeOdemes.KayitTarihi,GETDATE()) as Month,DateDiff(YEAR,dbo.uyeOdemes.KayitTarihi,GETDATE()) as Year,dbo.uyeOdemes.KayitTarihi,GETDATE(),DATEADD (DAY , 30 ,dbo.uyeOdemes.KayitTarihi) as SonBitis ,DateDiff(DAY,GETDATE(),DATEADD (DAY , 120 ,dbo.uyeOdemes.KayitTarihi)) FROM dbo.uyeOdemes";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        columnData.Add(result.GetValue(0).ToString());
                    }
                }
            }
            return Ok(columnData);

        }

        [HttpGet]
        [Route("aktiflikGuncelle")]
        public string str()
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC zamanGuncelle2";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        
                    }
                }
            }
            return "Başarılı";
        }

        [HttpGet]
        [Route("UyeAktiflik")]
        public ActionResult getAktiflik()
        {
            var aktifler = _context.UyeAktiflikler.ToList();
            return Ok(aktifler);
        }

        [HttpGet]
        [Route("UyeAktifmi")]
        public ActionResult getAktiflikById(int id)
        {
            var aktif = _Apprepo.GetUyeAktiflikById(id);
            return Ok(aktif);
        }

        [HttpGet]
        [Route("topSellerProduct")]
        public ActionResult getTopSellerProduct()
        {
            List<object[]> dataList = new List<object[]>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC TopSellerProduct";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        object[] tempRow = new object[result.FieldCount];
                        for (int i = 0; i < result.FieldCount; i++)
                        {
                            tempRow[i] = result[i];
                        }
                        dataList.Add(tempRow);
                    }
                }
            }
            return Ok(dataList);
        }




        [HttpGet]
        [Route("monthlyAktifUye")]
        public ActionResult getMonthlyActiveUser()
        {
            List<object[]> dataList = new List<object[]>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC getMonthlyActiveUser";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        object[] tempRow = new object[result.FieldCount];
                        for (int i = 0; i < result.FieldCount; i++)
                        {
                            tempRow[i] = result[i];
                        }
                        dataList.Add(tempRow);
                    }
                }
            }
            return Ok(dataList);
        }




        #endregion


        #region PostRequests
        [HttpPost]
        [Authorize]
        [Route("uyeEkle")]
        public ActionResult AddUye([FromBody]Uye uye)
        {
            _Apprepo.Add(uye);
            _Apprepo.SaveAll();
            return Ok(uye);
        }

        [HttpPost]
        [Authorize]
        [Route("VucutBilgiEkle")]
        public ActionResult AddVucutBilgi([FromBody]UyeVucutInfo uyeVucutInfo)
        {
            _Apprepo.Add(uyeVucutInfo);
            _Apprepo.SaveAll();
            return Ok(uyeVucutInfo);
        }

        [HttpPost]
        [Authorize]
        [Route("ProgramEkle")]
        public ActionResult addUyeProgram([FromBody] int uyeId)
        {
            UyeProgram uyeProgram = new UyeProgram();
            uyeProgram.UyeId = uyeId;
            _Apprepo.Add(uyeProgram);
            _Apprepo.SaveAll();
            return Ok(uyeProgram);
        }

        [HttpPost]
        [Authorize]
        [Route("antrenmanEkle")]
        public ActionResult addAntrenmanForProgram(Antrenman antrenman)
        {
            _Apprepo.Add(antrenman);
            _Apprepo.SaveAll();
            return Ok(antrenman);
        }

        [HttpPost]
        [Authorize]
        [Route("urunEkle")]
        public ActionResult addUrun([FromBody] Urun urun)
        {
            _Apprepo.Add(urun);
            _Apprepo.SaveAll();
            return Ok(urun);
        }

        [HttpPost]

        [Route("giderEkle")]
        public ActionResult addGider([FromBody] Gider gider)
        {
            _Apprepo.Add(gider);
            _Apprepo.SaveAll();
            return Ok(gider);
        }
        [HttpPost]
        [Authorize]
        [Route("odemeEkle")]
        public ActionResult addOdeme([FromBody] UyeOdeme uyeOdeme)
        {
            _Apprepo.Add(uyeOdeme);
            _Apprepo.SaveAll();
            return Ok(uyeOdeme);
        }

        [HttpPost]
        [Authorize]
        [Route("satisEkle")]
        public ActionResult addSatis([FromBody] satis satis)
        {
            _Apprepo.Add(satis);
            _Apprepo.SaveAll();
            return Ok(satis);
        }

        [HttpPost]
        [Authorize]
        [Route("uyeGuncelle")]
        public ActionResult UpdateUye([FromBody]Uye uye)
        {
            _Apprepo.Update(uye);
            _Apprepo.SaveAll();
            return Ok(uye);
        }

        [HttpPost]
        [Authorize]
        [Route("UrunGuncelle")]
        public ActionResult UpdateUrun([FromBody]Urun urun)
        {
            _Apprepo.Update(urun);
            _Apprepo.SaveAll();
            return Ok(urun);
        }







        #endregion


        #region DeleteRequests

        [HttpDelete]
        [Authorize]
        [Route("uyeSil")]
        public ActionResult deleteUye(int id)
        {
            _Apprepo.DeleteById(id);
            _Apprepo.SaveAll();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("urunSil")]
        public ActionResult deleteUrun(int id)
        {
            _Apprepo.DeleteUrunById(id);
            _Apprepo.SaveAll();
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        [Route("giderSil")]
        public ActionResult deleteGider(int id)
        {
            _Apprepo.DeleteGiderById(id);
            _Apprepo.SaveAll();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("vucutSil")]
        public ActionResult deleteVucutBilgi(int id)
        {
            _Apprepo.DeleteVucutBilgiById(id);
            _Apprepo.SaveAll();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("antrenmanSil")]
        public ActionResult deleteAntrenman(int id)
        {
            _Apprepo.DeleteAntrenmanById(id);
            _Apprepo.SaveAll();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("odemeSil")]
        public ActionResult deleteOdeme(int id)
        {
            _Apprepo.DeleteOdemeById(id);
            _Apprepo.SaveAll();
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("satisSil")]
        public ActionResult deleteSatis(int id)
        {
            _Apprepo.DeleteSatisById(id);
            _Apprepo.SaveAll();
            return Ok();
        }



        #endregion



        #region MailOperations

        [HttpPost]
        [Authorize]
        [Route("Sendemail")]
        public async Task<ActionResult> SendEmail([FromBody]email mail)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(mail.FromEmail));  
                message.From = new MailAddress("kursatcoskun.esogu@gmail.com"); 
                message.Subject = mail.EmailSubject;
                message.Body = string.Format(body, mail.FromName, mail.FromEmail, mail.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "kursatcoskun.esogu@gmail.com", 
                        Password = "bjk19961996" 
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                }
            }
            return Ok(mail);
        }

        #endregion
    }
}