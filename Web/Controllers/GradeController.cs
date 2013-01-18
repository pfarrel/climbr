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
    public class GradeController : ClimbrController
    {
        //
        // GET: /Grade/
        public ActionResult Index()
        {
            return View(Context.Grades.ToList());
        }

        //
        // GET: /Grade/Details/5
        public ActionResult Details(int id = 0)
        {
            Grade grade = Context.Grades.Find(id);
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
                Context.Grades.Add(grade);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grade);
        }
    }
}