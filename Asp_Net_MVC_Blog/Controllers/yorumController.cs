using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asp_Net_MVC_Blog.Models.sınıflar;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class yorumController : Controller
    {
        private Contex db = new Contex();

        // GET: yorum
        public ActionResult Index()
        {
            var yorum = db.yorum.Include(y => y.Makale).OrderByDescending(x=>x.YorumId);
            return View(yorum.ToList());
        }

        // GET: yorum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yorum yorum = db.yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // GET: yorum/Create
        public ActionResult Create()
        {
            ViewBag.Mid = new SelectList(db.makale, "Mid", "Mbaslik");
            return View();
        }

        // POST: yorum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumId,Icerik,onay,kullaniciadi,Mid")] yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.yorum.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mid = new SelectList(db.makale, "Mid", "Mbaslik", yorum.Mid);
            return View(yorum);
        }

        // GET: yorum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yorum yorum = db.yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mid = new SelectList(db.makale, "Mid", "Mbaslik", yorum.Mid);
            return View(yorum);
        }

        // POST: yorum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumId,Icerik,onay,kullaniciadi,Mid")] yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mid = new SelectList(db.makale, "Mid", "Mbaslik", yorum.Mid);
            return View(yorum);
        }

        // GET: yorum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yorum yorum = db.yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // POST: yorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yorum yorum = db.yorum.Find(id);
            db.yorum.Remove(yorum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
