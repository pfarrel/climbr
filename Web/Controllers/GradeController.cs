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
    public class GradeController : Controller
    {
        private ClimbrContext db = new ClimbrContext();

        //
        // GET: /Grade/
        public ActionResult Index()
        {
            return View(db.Grades.ToList());
        }

        //
        // GET: /Grade/Details/5
        public ActionResult Details(int id = 0)
        {
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        //
        // GET: /Grade/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Grade/Create
        [HttpPost]
        public ActionResult Create(Grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Grades.Add(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grade);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}