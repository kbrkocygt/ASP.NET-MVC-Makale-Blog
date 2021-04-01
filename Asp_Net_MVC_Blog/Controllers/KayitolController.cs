using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class KayitolController : Controller
    {
        // GET: Kayitol
        Contex db = new Contex();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet] //sayfa ilk acıldıgında ekleme yapma
        public ActionResult Uyeekle()
        {
            return View();
        }
        [HttpPost]//calıstıgı anda null deger  kaydetmesın
        public ActionResult Uyeekle(uye u1)
        {
            db.uye.Add(u1); //u1 geleni uye tablosuna ekle 
            db.SaveChanges();
            ViewBag.Uyari = "Başarı ile üye oldunuz:)";
            return View();
           
        }
    }
}