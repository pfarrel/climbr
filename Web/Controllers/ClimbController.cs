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
    public class ClimbController : ClimbrController
    {
        //
        // GET: /Climb/
        public ActionResult Index()
        {
            return View(Context.Climbs.ToList());
        }

        //
        // GET: /Climb/Details/5
        public ActionResult Details(int id = 0)
        {
            Climb climb = Context.Climbs.Find(id);
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
            var viewModel = new CreateClimbViewModel();

            var userId = Context.Users.Single(u => u.UserName == User.Identity.Name).Id;
            var lastLocation = Context.Climbs
                .Where(c => c.ClimberId == userId)
                .OrderByDescending(c => c.Date)
                .Select(c => c.Route.LocationId)
                .FirstOrDefault();

            viewModel.LocationId = lastLocation;

            ViewBag.Locations = Context.Locations.ToList();
            ViewBag.LastLocation = lastLocation;

            ViewBag.Routes = Context.Routes.ToList();
            ViewBag.ClimbTypes = Context.ClimbTypes.ToList();

            return View(viewModel);
        }

        //
        // POST: /Climb/Create
        [HttpPost]
        public ActionResult Create(CreateClimbViewModel createClimb)
        {
            Climb climb = new Climb();
            if (TryUpdateModel(climb))
            {
                climb.Climber = Context.Users.Single(u => u.UserName == User.Identity.Name);
                climb.Date = DateTime.Now;

                Context.Climbs.Add(climb);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(climb);
        }
    }
}