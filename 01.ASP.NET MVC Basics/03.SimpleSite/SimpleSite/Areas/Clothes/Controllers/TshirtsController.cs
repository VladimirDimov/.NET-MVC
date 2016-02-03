using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSite.Areas.Clothes.Controllers
{
    public class TshirtsController : Controller
    {
        // GET: Clothes/Tshirts
        public ActionResult Index()
        {
            return View();
        }
    }
}