using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ClimbrController : Controller
    {
        private ClimbrContext context;
        protected ClimbrContext Context
        {
            get
            {
                if (context == null) { context = new ClimbrContext(); }
                return context;
            }
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
        }
    }
}
