using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSite.Areas.Electronics.Controllers
{
    public class ComputersController : Controller
    {
        // GET: Electronics/Computers
        public ActionResult Index()
        {
            return View();
        }
    }
}