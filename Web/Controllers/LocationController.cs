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
    public class LocationController : ClimbrController
    {
        public ActionResult Index()
        {
            return View(Context.Locations.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Location location = Context.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Location createlocation)
        {
            Location location = new Location();
            if (TryUpdateModel(location))
            {
                location.AddedBy = Context.Users.Single(u => u.UserName == User.Identity.Name);
                Context.Locations.Add(location);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createlocation);
        }
    }
}