using AutoMapper;
using MoviesInfo.Models;
using MoviesInfo.Services;
using MoviesInformation.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace MoviesInformation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/movies");
        }
    }
}