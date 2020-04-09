using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using mis4200_team15.DAL;
using mis4200_team15.Models;

namespace mis4200_team15.Controllers
{
    public class userDetailsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: userDetails
        public ActionResult Index()
        {
            var userDetails = db.userDetails.Include(a => a.businessUnits).Include(a => a.Locations);
            return View(db.userDetails.ToList());
        }

        // GET: userDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.userDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // GET: userDetails/Create
        public ActionResult Create()
        {
            ViewBag.businessUnitsID = new SelectList(db.businessUnits, "businessUnitsID", "Unit");
            ViewBag.locationsID = new SelectList(db.Locations, "locationsID", "fullLocation");
            return View();
        }

        // POST: userDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,PhoneNumber,businessUnitsID,locationsID,hireDate")] userDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                Guid memberId; //create variable to hold the GUID
                //userDetails.ID = Guid.NewGuid();
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                userDetails.ID = memberId;
                db.userDetails.Add(userDetails);
                try 
	{	        
		 db.SaveChanges();
                return RedirectToAction("Index");
	}
	catch (Exception)
	{
return View("DuplicateUser");
		
	}
                
              
            }

            return View(userDetails);
        }

        // GET: userDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)

            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            userDetails userDetails = db.userDetails.Find(id);

            if (userDetails == null)

            {

                return HttpNotFound();

            }

            Guid memberID;

            Guid.TryParse(User.Identity.GetUserId(), out memberID);

            if (userDetails.ID == memberID)

            {

                return View(userDetails);

            }

            else

            {

                return View("NotAuthenticated");

            }
            //userDetails userDetails = db.userDetails.Find(id);
           // if (userDetails == null)
           // {
            //    return HttpNotFound();
           // }
            //return View(userDetails);
        }

        // POST: userDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,PhoneNumber,businessUnitsID,locationsID,hireDate")] userDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.businessUnitsID = new SelectList(db.businessUnits, "businessUnitsID", "Unit", userDetails.businessUnitsID);
            ViewBag.locationsID = new SelectList(db.Locations, "locationsID", "fullLocation", userDetails.locationsID);
            return View(userDetails);
        }

        // GET: userDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.userDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: userDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            userDetails userDetails = db.userDetails.Find(id);
            db.userDetails.Remove(userDetails);
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
