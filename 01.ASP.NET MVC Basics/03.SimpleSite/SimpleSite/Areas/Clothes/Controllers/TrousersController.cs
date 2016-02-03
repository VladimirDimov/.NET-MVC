using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSite.Areas.Clothes.Controllers
{
    public class TrousersController : Controller
    {
        // GET: Clothes/Trousers
        public ActionResult Index()
        {
            return View();
        }
    }
}