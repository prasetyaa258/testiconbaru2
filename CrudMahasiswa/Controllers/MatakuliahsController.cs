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
    public class MatakuliahsController : Controller
    {
        private MahasiswaDBEntities db = new MahasiswaDBEntities();

        // GET: Matakuliahs
        public ActionResult Index()
        {
            return View(db.Matakuliahs.ToList());
        }

        // GET: Matakuliahs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matakuliah matakuliah = db.Matakuliahs.Find(id);
            if (matakuliah == null)
            {
                return HttpNotFound();
            }
            return View(matakuliah);
        }

        // GET: Matakuliahs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matakuliahs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatakuliahID,Nama_matakuliah,Sks")] Matakuliah matakuliah)
        {
            if (ModelState.IsValid)
            {
                db.Matakuliahs.Add(matakuliah);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matakuliah);
        }

        // GET: Matakuliahs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matakuliah matakuliah = db.Matakuliahs.Find(id);
            if (matakuliah == null)
            {
                return HttpNotFound();
            }
            return View(matakuliah);
        }

        // POST: Matakuliahs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatakuliahID,Nama_matakuliah,Sks")] Matakuliah matakuliah)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matakuliah).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matakuliah);
        }

        // GET: Matakuliahs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matakuliah matakuliah = db.Matakuliahs.Find(id);
            if (matakuliah == null)
            {
                return HttpNotFound();
            }
            return View(matakuliah);
        }

        // POST: Matakuliahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matakuliah matakuliah = db.Matakuliahs.Find(id);
            db.Matakuliahs.Remove(matakuliah);
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
