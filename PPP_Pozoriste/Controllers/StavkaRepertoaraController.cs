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
    public class StavkaRepertoaraController : Controller
    {
        private PozoristeEntities1 db = new PozoristeEntities1();

        // GET: StavkaRepertoara
        public ActionResult Index()
        {
            var stavkaRepertoara = db.StavkaRepertoara.Include(s => s.Predstava);
            return View(stavkaRepertoara.ToList());
        }

        // GET: StavkaRepertoara/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaRepertoara stavkaRepertoara = db.StavkaRepertoara.Find(id);
            if (stavkaRepertoara == null)
            {
                return HttpNotFound();
            }
            return View(stavkaRepertoara);
        }

        // GET: StavkaRepertoara/Create
        public ActionResult Create()
        {
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave");
            return View();
        }

        // POST: StavkaRepertoara/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StavkaID,PredstavaID,DatumPrikazivanja,Status")] StavkaRepertoara stavkaRepertoara)
        {
            if (ModelState.IsValid)
            {
                db.StavkaRepertoara.Add(stavkaRepertoara);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave", stavkaRepertoara.PredstavaID);
            return View(stavkaRepertoara);
        }

        // GET: StavkaRepertoara/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaRepertoara stavkaRepertoara = db.StavkaRepertoara.Find(id);
            if (stavkaRepertoara == null)
            {
                return HttpNotFound();
            }
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave", stavkaRepertoara.PredstavaID);
            return View(stavkaRepertoara);
        }

        // POST: StavkaRepertoara/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StavkaID,PredstavaID,DatumPrikazivanja,Status")] StavkaRepertoara stavkaRepertoara)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavkaRepertoara).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave", stavkaRepertoara.PredstavaID);
            return View(stavkaRepertoara);
        }

        // GET: StavkaRepertoara/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaRepertoara stavkaRepertoara = db.StavkaRepertoara.Find(id);
            if (stavkaRepertoara == null)
            {
                return HttpNotFound();
            }
            return View(stavkaRepertoara);
        }

        // POST: StavkaRepertoara/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StavkaRepertoara stavkaRepertoara = db.StavkaRepertoara.Find(id);
            db.StavkaRepertoara.Remove(stavkaRepertoara);
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
