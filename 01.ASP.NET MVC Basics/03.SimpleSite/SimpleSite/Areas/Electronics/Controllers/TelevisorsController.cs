using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSite.Areas.Electronics.Controllers
{
    public class TelevisorsController : Controller
    {
        // GET: Electronics/Televisors
        public ActionResult Index()
        {
            return View();
        }
    }
}