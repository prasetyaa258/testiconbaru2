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
    public class JurusansController : Controller
    {
        private MahasiswaDBEntities db = new MahasiswaDBEntities();

        // GET: Jurusans
        public ActionResult Index()
        {
            return View(db.Jurusans.ToList());
        }

        // GET: Jurusans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jurusan jurusan = db.Jurusans.Find(id);
            if (jurusan == null)
            {
                return HttpNotFound();
            }
            return View(jurusan);
        }

        // GET: Jurusans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jurusans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JurusanID,Id_jurusan,Nama_Jurusan")] Jurusan jurusan)
        {
            if (ModelState.IsValid)
            {
                db.Jurusans.Add(jurusan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jurusan);
        }

        // GET: Jurusans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jurusan jurusan = db.Jurusans.Find(id);
            if (jurusan == null)
            {
                return HttpNotFound();
            }
            return View(jurusan);
        }

        // POST: Jurusans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JurusanID,Id_jurusan,Nama_Jurusan")] Jurusan jurusan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jurusan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jurusan);
        }

        // GET: Jurusans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jurusan jurusan = db.Jurusans.Find(id);
            if (jurusan == null)
            {
                return HttpNotFound();
            }
            return View(jurusan);
        }

        // POST: Jurusans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jurusan jurusan = db.Jurusans.Find(id);
            db.Jurusans.Remove(jurusan);
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
