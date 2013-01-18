using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Domain;

namespace Web.Controllers
{
    public class RouteController : ClimbrController
    {
        public ActionResult Index()
        {
            return View(Context.Routes.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Route route = Context.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        public ActionResult Create()
        {
            ViewBag.ClimbTypes = Context.ClimbTypes.ToList();
            ViewBag.Colors = Context.Colors.ToList();
            ViewBag.Grades = Context.Grades.ToList();
            ViewBag.Locations = Context.Locations.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Route createRoute)
        {
            Route route = new Route();
            if (TryUpdateModel(route))
            {
                route.AddedBy = Context.Users.Single(u => u.UserName == User.Identity.Name);
                Context.Routes.Add(route);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Colors = Context.Colors.ToList();
            ViewBag.ClimbTypes = Context.ClimbTypes.ToList();
            ViewBag.Grades = Context.Grades.ToList();
            ViewBag.Locations = Context.Locations.ToList();

            return View(route);
        }
    }
}