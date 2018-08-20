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
    public class GlumiController : Controller
    {
        private PozoristeEntities1 db = new PozoristeEntities1();

        // GET: Glumi
        public ActionResult Index()
        {
            var glumi = db.Glumi.Include(g => g.Glumac).Include(g => g.Predstava);
            return View(glumi.ToList());
        }

        // GET: Glumi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glumi glumi = db.Glumi.Find(id);
            if (glumi == null)
            {
                return HttpNotFound();
            }
            return View(glumi);
        }

        // GET: Glumi/Create
        public ActionResult Create()
        {
            ViewBag.JMBG = new SelectList(db.Glumac, "JMBG", "Ime");
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave");
            return View();
        }

        // POST: Glumi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlumiID,JMBG,PredstavaID")] Glumi glumi)
        {
            if (ModelState.IsValid)
            {
                db.Glumi.Add(glumi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JMBG = new SelectList(db.Glumac, "JMBG", "Ime", glumi.JMBG);
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave", glumi.PredstavaID);
            return View(glumi);
        }

        // GET: Glumi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glumi glumi = db.Glumi.Find(id);
            if (glumi == null)
            {
                return HttpNotFound();
            }
            ViewBag.JMBG = new SelectList(db.Glumac, "JMBG", "Ime", glumi.JMBG);
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave", glumi.PredstavaID);
            return View(glumi);
        }

        // POST: Glumi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlumiID,JMBG,PredstavaID")] Glumi glumi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glumi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JMBG = new SelectList(db.Glumac, "JMBG", "Ime", glumi.JMBG);
            ViewBag.PredstavaID = new SelectList(db.Predstava, "PredstavaID", "NazivPredstave", glumi.PredstavaID);
            return View(glumi);
        }

        // GET: Glumi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glumi glumi = db.Glumi.Find(id);
            if (glumi == null)
            {
                return HttpNotFound();
            }
            return View(glumi);
        }

        // POST: Glumi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Glumi glumi = db.Glumi.Find(id);
            db.Glumi.Remove(glumi);
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
