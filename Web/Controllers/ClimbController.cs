using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ClimbController : Controller
    {
        private ClimbrContext db = new ClimbrContext();

        //
        // GET: /Climb/

        public ActionResult Index()
        {
            return View(db.Climbs.ToList());
        }

        //
        // GET: /Climb/Details/5

        public ActionResult Details(int id = 0)
        {
            Climb climb = db.Climbs.Find(id);
            if (climb == null)
            {
                return HttpNotFound();
            }
            return View(climb);
        }

        //
        // GET: /Climb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Climb/Create

        [HttpPost]
        public ActionResult Create(Climb climb)
        {
            if (ModelState.IsValid)
            {
                db.Climbs.Add(climb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(climb);
        }

        //
        // GET: /Climb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Climb climb = db.Climbs.Find(id);
            if (climb == null)
            {
                return HttpNotFound();
            }
            return View(climb);
        }

        //
        // POST: /Climb/Edit/5

        [HttpPost]
        public ActionResult Edit(Climb climb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(climb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(climb);
        }

        //
        // GET: /Climb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Climb climb = db.Climbs.Find(id);
            if (climb == null)
            {
                return HttpNotFound();
            }
            return View(climb);
        }

        //
        // POST: /Climb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Climb climb = db.Climbs.Find(id);
            db.Climbs.Remove(climb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}