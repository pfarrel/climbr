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
            ViewBag.Routes = db.Routes.ToList();

            return View();
        }

        //
        // POST: /Climb/Create
        [HttpPost]
        public ActionResult Create(Climb createClimb)
        {
            Climb climb = new Climb();
            if (TryUpdateModel(climb))
            {
                climb.Climber = db.Users.Single(u => u.UserName == User.Identity.Name);
                db.Climbs.Add(climb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Routes = db.Routes.ToList();

            return View(climb);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}