using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Models;
using Twitter.Services;

namespace Twitter.Web.Controllers
{
    public class HomeController : Controller
    {
        private TwitsServices twits;

        public HomeController(TwitsServices twits)
        {
            this.twits = twits;
        }

        public ActionResult Index()
        {
            return View("Index", GetCachedTwits());
        }

        [OutputCache(Duration = 15 * 60)]
        private ICollection<Twit> GetCachedTwits()
        {
            return this.twits.GetByTag("#fail").ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}