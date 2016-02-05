using AutoMapper;
using MoviesInfo.Models;
using MoviesInfo.Services;
using MoviesInfo.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace MoviesInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/movies");
        }
    }
}