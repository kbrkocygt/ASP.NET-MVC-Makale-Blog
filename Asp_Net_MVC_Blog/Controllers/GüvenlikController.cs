using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class GüvenlikController : Controller
    {
        Contex db = new Contex();
        // GET: Güvenlik
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(uye u1)
        {
            var bilgiler = db.uye.FirstOrDefault(x => x.Ukullaniciadi == u1.Ukullaniciadi && x.Usifre == u1.Usifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Ukullaniciadi,false);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı adı veya şifre yanlış";
                return View();
            }
           
        }
        public ActionResult Logout(uye u1)
        {
            var bilgiler = db.uye.FirstOrDefault(x => x.Ukullaniciadi == u1.Ukullaniciadi && x.Usifre == u1.Usifre);
            if (bilgiler==null)
            {
                return RedirectToAction("Login", "Güvenlik");
            }
            return View();
            
        }
    }
}