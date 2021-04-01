using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class galeriController : Controller
    {
       private Contex db = new Contex();
        // GET: galeri
        public ActionResult Index()
        {
            return View(db.galeri.ToList());
        }
        public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//text area ile ilgili dogrulamayı false gec
        public ActionResult Create(galeri galeri,HttpPostedFileBase Ryolu)
        {
            if (ModelState.IsValid)
            {

                if (Ryolu != null)
                {
                    WebImage img = new WebImage(Ryolu.InputStream);//image nesnesin oluşturduk
                    FileInfo imginfo = new FileInfo(Ryolu.FileName);//gelen imaje nin ismini aldık
                    String mimage = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500); //GENİSLİK VE YUKSEKLIK
                    img.Save("~/Uploads/galeri/" + mimage);
                    galeri.Ryolu = "/Uploads/galeri/" + mimage;


                }
                db.galeri.Add(galeri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galeri);
        }
        public ActionResult Edit(int? id)  //soru işareti bos bir id gelebir
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek resim bulunamadı";
            }
            var r = db.galeri.Find(id);
            if (r== null)
            {
                return HttpNotFound();
            }
           
            return View(r);
          
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, galeri galeri, HttpPostedFileBase Ryolu)
        {
            if (ModelState.IsValid)
            {
                var r = db.galeri.Where(x => x.galeriİD == id).SingleOrDefault();
                if (Ryolu != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(r.Ryolu)))
                    {
                        System.IO.File.Delete(Server.MapPath(r.Ryolu));
                    }
                    WebImage img = new WebImage(Ryolu.InputStream);
                    FileInfo imginfo = new FileInfo(Ryolu.FileName);
                    string resim = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500); //GENİSLİK VE YUKSEKLIK
                    img.Save("~/Uploads/galeri/" + resim);
                    r.Ryolu = "/Uploads/galeri/" + resim;
                }

                r.Rbaslik = galeri.Rbaslik;


               

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
       }
            
        public ActionResult Delete(int? id)
        {
            if(id==null)
            {

                return HttpNotFound();

            }
            var r = db.galeri.Find(id);
            if(r==null)
            {
                return HttpNotFound();
            }
            db.galeri.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }



    }
    }
