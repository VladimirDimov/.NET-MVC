﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSite.Controllers
{
    public class ArchiveController : Controller
    {
        // GET: Archive
        public ActionResult Index(string year)
        {
            ViewBag.Year = year;
            return View();
        }
    }
}