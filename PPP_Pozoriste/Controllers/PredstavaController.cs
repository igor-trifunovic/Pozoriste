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
    public class PredstavaController : Controller
    {
        private PozoristeEntities1 db = new PozoristeEntities1();

        // GET: Predstava
        public ActionResult Index()
        {
            return View(db.Predstava.ToList());
        }

        // GET: Predstava/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predstava predstava = db.Predstava.Find(id);
            if (predstava == null)
            {
                return HttpNotFound();
            }
            return View(predstava);
        }

        // GET: Predstava/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predstava/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PredstavaID,NazivPredstave,Zanr,Duzina,Scenarista,Reditelj")] Predstava predstava)
        {
            if (ModelState.IsValid)
            {
                db.Predstava.Add(predstava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predstava);
        }

        // GET: Predstava/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predstava predstava = db.Predstava.Find(id);
            if (predstava == null)
            {
                return HttpNotFound();
            }
            return View(predstava);
        }

        // POST: Predstava/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PredstavaID,NazivPredstave,Zanr,Duzina,Scenarista,Reditelj")] Predstava predstava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predstava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predstava);
        }

        // GET: Predstava/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predstava predstava = db.Predstava.Find(id);
            if (predstava == null)
            {
                return HttpNotFound();
            }
            return View(predstava);
        }

        // POST: Predstava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predstava predstava = db.Predstava.Find(id);
            db.Predstava.Remove(predstava);
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
