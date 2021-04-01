using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private Contex db = new Contex();

       

        public ActionResult Index()
        {
            //db.Configuration.LazyLoadingEnabled = false; //
            return View(db.makale.Include("kategori").ToList().OrderByDescending(x=>x.Mid)); //kategori id ye gore kategori  adını listeledik
        }
        public ActionResult Create()
        {
            ViewBag.Kid = new  SelectList(db.kategori, "Kid","Kadi");
            return View();
        }
        [HttpPost]//form yuklendıgınde ana işlemler burda  yapılır
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]//veri guvenliğini saglar 
        public ActionResult Create(makale makale,HttpPostedFileBase Mresim)
        {
            
            
                if (Mresim != null)
                {
                    WebImage img = new WebImage(Mresim.InputStream);
                    FileInfo imginfo = new FileInfo(Mresim.FileName);
                    String mimage = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 500); //GENİSLİK VE YUKSEKLIK
                    img.Save("~/Uploads/makale/" + mimage);
                    makale.Mresim = "/Uploads/makale/" + mimage;


                }
                db.makale.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index"); //yönlendirme yap
            
          
                

          



        }
        public ActionResult Edit(int  id)
        {
            
                if (id == null)
                {
                    return HttpNotFound();
                }
                var m = db.makale.Where(x => x.Mid == id).SingleOrDefault();
                if (m == null) //kayıt bos ise
                {
                    return HttpNotFound();
                }
            //veri tasıma islemi
            ViewBag.Kid = new SelectList(db.kategori, "Kid", "Kadi", m.Kid);

            return View(m);
            
          
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //using begin form dedigim için ; 
        [ValidateInput(false)]
        public ActionResult Edit(int id,makale makale,HttpPostedFileBase Mresim)
        {
            
            
                if (ModelState.IsValid)//model dogrulandıysa işlemlere basla
                {
                    var m = db.makale.Where(x => x.Mid == id).SingleOrDefault();
                    if (Mresim != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(m.Mresim)))
                        {
                            System.IO.File.Delete(Server.MapPath(m.Mresim));
                        }
                        WebImage img = new WebImage(Mresim.InputStream);
                        FileInfo imginfo = new FileInfo(Mresim.FileName);
                        string mresim = Guid.NewGuid().ToString() + imginfo.Extension;
                        img.Resize(600, 500); //GENİSLİK VE YUKSEKLIK
                        img.Save("~/Uploads/Blog/" + mresim);
                        m.Mresim = "/Uploads/Blog/" + mresim;
                    }
                    m.Mbaslik = makale.Mbaslik;
                    m.Micerik = makale.Micerik;
                    m.Mözet = makale.Mözet;
                    m.Mtarih = makale.Mtarih;
                    m.Kid = makale.Kid;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(makale);
            
           

        }
        //[HttpPost]
        public ActionResult Delete(int? id)
        {
            var m = db.makale.Find(id);
            if (m==null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(m.Mresim))) //daha önce yuklenmıs bir resim varsa 
            {
                System.IO.File.Delete(Server.MapPath(m.Mresim));
            }
            db.makale.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}