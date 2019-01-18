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
    public class MasterdatasController : Controller
    {
        private MahasiswaDBEntities db = new MahasiswaDBEntities();

        // GET: Masterdatas
        public ActionResult Index()
        {
            var masterdatas = db.Masterdatas.Include(m => m.Falkuta).Include(m => m.Jurusan).Include(m => m.Mahasiswa).Include(m => m.Matakuliah);
            return View(masterdatas.ToList());
        }

        public ActionResult GetData()
        {
            using (MahasiswaDBEntities db = new MahasiswaDBEntities())
            {
                List<Mahasiswa> empList = db.Mahasiswas.ToList<Mahasiswa>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Masterdatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masterdata masterdata = db.Masterdatas.Find(id);
            if (masterdata == null)
            {
                return HttpNotFound();
            }
            return View(masterdata);
        }

        // GET: Masterdatas/Create
        public ActionResult Create()
        {
            ViewBag.FalkutasID = new SelectList(db.Falkutas, "FalkutasID", "Nama_falkutas");
            ViewBag.JurusanID = new SelectList(db.Jurusans, "JurusanID", "Nama_jurusan");
            ViewBag.MahasiswaID = new SelectList(db.Mahasiswas, "MahasiswaID", "Nama_mhs");
            ViewBag.MatakuliahID = new SelectList(db.Matakuliahs, "MatakuliahID", "Nama_matakuliah");
            return View();
        }

        // POST: Masterdatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MasterdataID,MahasiswaID,FalkutasID,JurusanID,MatakuliahID")] Masterdata masterdata)
        {
            if (ModelState.IsValid)
            {
                db.Masterdatas.Add(masterdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FalkutasID = new SelectList(db.Falkutas, "FalkutasID", "Nama_Falkutas", masterdata.FalkutasID);
            ViewBag.JurusanID = new SelectList(db.Jurusans, "JurusanID", "Nama_jurusan", masterdata.JurusanID);
            ViewBag.MahasiswaID = new SelectList(db.Mahasiswas, "MahasiswaID", "Nama_mhs", masterdata.MahasiswaID);
            ViewBag.MatakuliahID = new SelectList(db.Matakuliahs, "MatakuliahID", "Nama_matakuliah", masterdata.MatakuliahID);
            return View(masterdata);
        }

        // GET: Masterdatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masterdata masterdata = db.Masterdatas.Find(id);
            if (masterdata == null)
            {
                return HttpNotFound();
            }
            ViewBag.FalkutasID = new SelectList(db.Falkutas, "FalkutasID", "Nama_falkutas", masterdata.FalkutasID);
            ViewBag.JurusanID = new SelectList(db.Jurusans, "JurusanID", "Nama_jurusan", masterdata.JurusanID);
            ViewBag.MahasiswaID = new SelectList(db.Mahasiswas, "MahasiswaID", "Nama_mhs", masterdata.MahasiswaID);
            ViewBag.MatakuliahID = new SelectList(db.Matakuliahs, "MatakuliahID", "Nama_matakuliah", masterdata.MatakuliahID);
            return View(masterdata);
        }

        // POST: Masterdatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MasterdataID,MahasiswaID,FalkutasID,JurusanID,MatakuliahID")] Masterdata masterdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FalkutasID = new SelectList(db.Falkutas, "FalkutasID", "Nama_falkutas", masterdata.FalkutasID);
            ViewBag.JurusanID = new SelectList(db.Jurusans, "JurusanID", "Nama_jurusan", masterdata.JurusanID);
            ViewBag.MahasiswaID = new SelectList(db.Mahasiswas, "MahasiswaID", "Nama_mhs", masterdata.MahasiswaID);
            ViewBag.MatakuliahID = new SelectList(db.Matakuliahs, "MatakuliahID", "Nama_matakuliah", masterdata.MatakuliahID);
            return View(masterdata);
        }

        // GET: Masterdatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masterdata masterdata = db.Masterdatas.Find(id);
            if (masterdata == null)
            {
                return HttpNotFound();
            }
            return View(masterdata);
        }

        // POST: Masterdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Masterdata masterdata = db.Masterdatas.Find(id);
            db.Masterdatas.Remove(masterdata);
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
