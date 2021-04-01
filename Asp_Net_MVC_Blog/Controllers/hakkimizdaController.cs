using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class hakkimizdaController : Controller
    {
        Contex db = new Contex();
        // GET: hakkimizda
        public ActionResult Index()
        {
            var h = db.hakkimizda.ToList();
            return View(h);
        }
        public ActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateInput(false)]//text area ile ilgili dogrulamayı false gec
        public ActionResult Create(hakkimizda hakkimizda, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {

                if (resim != null)
                {
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo imginfo = new FileInfo(resim.FileName);
                    String image = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500); //GENİSLİK VE YUKSEKLIK
                    img.Save("~/Uploads/hakkimizda/" + image);
                   hakkimizda.resim = "/Uploads/hakkimizda/" + image;


                }
                db.hakkimizda.Add(hakkimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hakkimizda);
        }
        public ActionResult Edit(int? id)  //soru işareti bos bir id gelebir
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek resim bulunamadı";
            }
            var r = db.hakkimizda.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }

            return View(r);

        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, hakkimizda hakkimizda, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                var r = db.hakkimizda.Where(x => x.id == id).SingleOrDefault();
                if (resim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(r.resim)))
                    {
                        System.IO.File.Delete(Server.MapPath(r.resim));
                    }
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo imginfo = new FileInfo(resim.FileName);
                    string imaj = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500); //GENİSLİK VE YUKSEKLIK
                    img.Save("~/Uploads/hakkimizda/" + imaj);
                    r.resim = "/Uploads/hakkimizda/" + imaj;
                }




                r.aciklama = hakkimizda.aciklama;
              

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var h= db.hakkimizda.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(h.resim)))
            {
                System.IO.File.Delete(Server.MapPath(h.resim));
            }
            db.hakkimizda.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}