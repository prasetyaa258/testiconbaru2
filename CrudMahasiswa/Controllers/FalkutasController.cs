using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudMahasiswa.Models;

namespace CrudMahasiswa.Controllers
{
    public class FalkutasController : Controller
    {
        private MahasiswaDBEntities db = new MahasiswaDBEntities();

        // GET: Falkutas
        public ActionResult Index()
        {
            return View(db.Falkutas.ToList());
        }

        // GET: Falkutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falkuta falkuta = db.Falkutas.Find(id);
            if (falkuta == null)
            {
                return HttpNotFound();
            }
            return View(falkuta);
        }

        // GET: Falkutas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Falkutas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FalkutasID,Id_falkutas,Nama_falkutas")] Falkuta falkuta)
        {
            if (ModelState.IsValid)
            {
                db.Falkutas.Add(falkuta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(falkuta);
        }

        // GET: Falkutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falkuta falkuta = db.Falkutas.Find(id);
            if (falkuta == null)
            {
                return HttpNotFound();
            }
            return View(falkuta);
        }

        // POST: Falkutas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FalkutasID,Id_falkutas,Nama_falkutas")] Falkuta falkuta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(falkuta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(falkuta);
        }

        // GET: Falkutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falkuta falkuta = db.Falkutas.Find(id);
            if (falkuta == null)
            {
                return HttpNotFound();
            }
            return View(falkuta);
        }

        // POST: Falkutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Falkuta falkuta = db.Falkutas.Find(id);
            db.Falkutas.Remove(falkuta);
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
