using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class uyeController : Controller
    {
        Contex db = new Contex();
        // GET: uye
        public ActionResult Index()
        {
            return View(db.uye.ToList());
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {

                return HttpNotFound();

            }
            var r = db.uye.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            db.uye.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}