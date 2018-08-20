using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPP_Pozoriste.Models;

namespace PPP_Pozoriste.Controllers
{
    public class RepertoarController : Controller
    {
        private PozoristeEntities1 db = new PozoristeEntities1();

        // GET: Repertoars
        public ActionResult Index()
        {
            var repertoar = db.Repertoar.Include(r => r.Mesec).Include(r => r.StavkaRepertoara);
            return View(repertoar.ToList());
        }

        // GET: Repertoars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repertoar repertoar = db.Repertoar.Find(id);
            if (repertoar == null)
            {
                return HttpNotFound();
            }
            return View(repertoar);
        }

        // GET: Repertoars/Create
        public ActionResult Create()
        {
            ViewBag.MesecID = new SelectList(db.Mesec, "MesecID", "Naziv");
            ViewBag.StavkaID = new SelectList(db.StavkaRepertoara, "StavkaID", "StavkaID");
            return View();
        }

        // POST: Repertoars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepertoarID,StavkaID,MesecID")] Repertoar repertoar)
        {
            if (ModelState.IsValid)
            {
                db.Repertoar.Add(repertoar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MesecID = new SelectList(db.Mesec, "MesecID", "Naziv", repertoar.MesecID);
            ViewBag.StavkaID = new SelectList(db.StavkaRepertoara, "StavkaID", "StavkaID", repertoar.StavkaID);
            return View(repertoar);
        }

        // GET: Repertoars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repertoar repertoar = db.Repertoar.Find(id);
            if (repertoar == null)
            {
                return HttpNotFound();
            }
            ViewBag.MesecID = new SelectList(db.Mesec, "MesecID", "Naziv", repertoar.MesecID);
            ViewBag.StavkaID = new SelectList(db.StavkaRepertoara, "StavkaID", "StavkaID", repertoar.StavkaID);
            return View(repertoar);
        }

        // POST: Repertoars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepertoarID,StavkaID,MesecID")] Repertoar repertoar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repertoar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MesecID = new SelectList(db.Mesec, "MesecID", "Naziv", repertoar.MesecID);
            ViewBag.StavkaID = new SelectList(db.StavkaRepertoara, "StavkaID", "StavkaID", repertoar.StavkaID);
            return View(repertoar);
        }

        // GET: Repertoars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repertoar repertoar = db.Repertoar.Find(id);
            if (repertoar == null)
            {
                return HttpNotFound();
            }
            return View(repertoar);
        }

        // POST: Repertoars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repertoar repertoar = db.Repertoar.Find(id);
            db.Repertoar.Remove(repertoar);
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
