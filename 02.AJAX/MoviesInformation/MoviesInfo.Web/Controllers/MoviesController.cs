using AutoMapper.QueryableExtensions;
using MoviesInfo.Models;
using MoviesInfo.Services;
using MoviesInformation.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesInformation.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesServices movies;
        private PeopleServices people;
        private StudiosServices studios;

        public MoviesController(
            MoviesServices movies,
            PeopleServices people,
            StudiosServices studios)
        {
            this.movies = movies;
            this.people = people;
            this.studios = studios;
        }

        // GET: Movies
        public ActionResult Index()
        {
            //Mapper.CreateMap<Movie, AllMoviesModel>();
            var movies = this.movies.All()
                .ProjectTo<AllMoviesModel>()
                .ToList();

            return View("Index", movies);
        }

        public ActionResult Details(int id)
        {
            var movie = MovieDetailsView.GetFromModel(this.movies.GetById(id));
            return PartialView("_MovieDetails", movie);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            this.movies.DeleteById(id);
            return PartialView("_Empty");
        }

        public ActionResult Edit(int id)
        {
            var movie = MovieDetailsView.GetFromModel(this.movies.GetById(id));
            ViewBag.People =
                this.GetAllPeople()
                .Select(p => new SelectListItem()
                {
                    Text = p.FirstName + " " + p.LastName,
                    Value = p.Id.ToString()
                })
                .ToList();

            ViewBag.Studios =
                this.GetAllStudios()
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
                .ToList();

            return PartialView("_MovieEdit", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MovieUpdateModel model)
        {
            var movie = this.movies.Update(MovieUpdateModel.ToModel(model));
            return PartialView("_MovieDetails", MovieDetailsView.GetFromModel(movie));
        }

        private ICollection<Person> GetAllPeople()
        {
            return this.people.All()
                .ToList();
        }

        private ICollection<Studio> GetAllStudios()
        {
            return this.studios.All()
                .ToList();
        }

        public ActionResult Cancel()
        {
            return this.Index();
        }
    }
}
