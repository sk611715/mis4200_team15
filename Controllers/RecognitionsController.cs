using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mis4200_team15.DAL;
using mis4200_team15.Models;

namespace mis4200_team15.Controllers
{
    public class RecognitionsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Recognitions
        public ActionResult Index()
        {
            var recognitions = db.Recognitions.Include(r => r.coreValues).Include(r => r.userDetails);
            return View(recognitions.ToList());
        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognitions recognitions = db.Recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            ViewBag.coreValuesID = new SelectList(db.coreValues, "coreValuesID", "valueName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullUserName");
            return View(recognitions);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            ViewBag.coreValuesID = new SelectList(db.coreValues, "coreValuesID", "valueName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullUserName");
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionsID,ID,recognitionDate,coreValuesID,Description")] Recognitions recognitions)
        {
            if (ModelState.IsValid)
            {
                db.Recognitions.Add(recognitions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coreValuesID = new SelectList(db.coreValues, "coreValuesID", "valueName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullUserName");
            return View(recognitions);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognitions recognitions = db.Recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            ViewBag.coreValuesID = new SelectList(db.coreValues, "coreValuesID", "valueName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullUserName");
            return View(recognitions);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionsID,ID,recognitionDate,coreValuesID,Description")] Recognitions recognitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognitions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coreValuesID = new SelectList(db.coreValues, "coreValuesID", "valueName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullUserName");
            return View(recognitions);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognitions recognitions = db.Recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            ViewBag.coreValuesID = new SelectList(db.coreValues, "coreValuesID", "valueName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullUserName");
            return View(recognitions);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognitions recognitions = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognitions);
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
