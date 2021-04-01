using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class DefaultController : Controller
    {
         private Contex db = new Contex();
        // GET: Default
        public ActionResult About()
        {
            var kayıt = db.hakkimizda.ToList().SingleOrDefault();
            return View(kayıt);

        }
        public ActionResult partialContact()
        {
            return View(db.iletisim.ToList().SingleOrDefault());
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string adsoyad = null, string mail = null, string konu = null, string mesaj = null)
        {
            if (adsoyad != null && mail != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com"; 
                WebMail.EnableSsl = true;
                WebMail.UserName = "makaleblogs@gmail.com";
                WebMail.Password = "makale123";
                WebMail.SmtpPort = 587;
                WebMail.Send("makaleblogs@gmail.com", konu, mail + "-" + mesaj);
                ViewBag.Uyarı = "Mesajınız başarıyla  Gönderilmiştir";

            }
            else
            {
                ViewBag.Uyarı = "Hata oluştu tekrar deneyiniz";
            }
            return View();
        }
        public ActionResult Index()
        {

           
            return View();
            
        }
       
       public ActionResult SliderPartial()
        {


            return View(db.galeri .ToList().OrderByDescending(x=>x.galeriİD));
        }
       
        public ActionResult  kategori()
        {
            return View(db.kategori.Include("makales").ToList().OrderBy(x => x.Kadi));
        }
        [Authorize]
        public  ActionResult Blog()
        {
            
            return View(db.makale.Include("kategori"). ToList().OrderByDescending(x => x.Mid));
        }
      public ActionResult BlogKategori(int id)
        {
            var b = db.makale.Include("kategori"). Where(x => x.kategori.Kid == id).ToList();
            return View(b);
        }
        public ActionResult blogdetay(int id)
        {
            return View(db.makale. Include("kategori").Include("yorum") .Where(x=>x.Mid==id).SingleOrDefault());
        }
        [Authorize]
        public ActionResult blogSonKayit()
        {
            return View(db.makale.ToList().OrderByDescending(x=>x.Mid));
        }
        public ActionResult anasayfa()
        {
            return View(db.makale.ToList().Last());
        }
        public JsonResult yorumyap(string kullaniciad , string yorum , int mid)
        {
            if (yorum==null)
            {
                return Json(true, JsonRequestBehavior.AllowGet); //eger nul ise kendine donsun
            }
            db.yorum.Add(new yorum { kullaniciadi = kullaniciad, Icerik = yorum, Mid = mid ,onay=false});
            db.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}