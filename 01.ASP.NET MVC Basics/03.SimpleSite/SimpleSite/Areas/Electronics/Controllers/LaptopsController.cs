using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSite.Areas.Electronics.Controllers
{
    public class LaptopsController : Controller
    {
        // GET: Electronics/Laptops
        public ActionResult Index()
        {
            return View();
        }
    }
}