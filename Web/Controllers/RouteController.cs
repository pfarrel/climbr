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
    public class RouteController : Controller
    {
        private ClimbrContext db = new ClimbrContext();

        //
        // GET: /Route/
        public ActionResult Index()
        {
            return View(db.Routes.ToList());
        }

        //
        // GET: /Route/Details/5
        public ActionResult Details(int id = 0)
        {
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // GET: /Route/Create
        public ActionResult Create()
        {
            ViewBag.Grades = db.Grades.ToList();
            ViewBag.Locations = db.Locations.ToList();

            return View();
        }

        //
        // POST: /Route/Create
        [HttpPost]
        public ActionResult Create(Route createRoute)
        {
            Route route = new Route();
            if (TryUpdateModel(route))
            {
                route.AddedBy = db.Users.Single(u => u.UserName == User.Identity.Name);
                db.Routes.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grades = db.Grades.ToList();
            ViewBag.Locations = db.Locations.ToList();

            return View(route);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}