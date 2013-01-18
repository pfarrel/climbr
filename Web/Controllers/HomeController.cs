using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : ClimbrController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
