using MoviesInfo.Data.Repository;
using MoviesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Services
{
    public class MoviesServices
    {
        private IRepository<Movie> movies;

        public MoviesServices(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> All()
        {
            return this.movies.All();
        }

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void DeleteById(int id)
        {
            this.movies.Delete(id);
            this.movies.SaveChanges();
        }

        public Movie Update(Movie model)
        {
            var movie = this.GetById(model.Id);

            movie.Title = model.Title;
            movie.Year = model.Year;

            foreach (PropertyInfo prop in model.GetType().GetProperties())
            {
                if (prop != null && prop.Name != "Id")
                {
                    typeof(Movie)
                        .GetProperty(prop.Name)
                        .SetValue(movie, prop.GetValue(model));
                }
            }

            //this.movies.Update(model);
            this.movies.SaveChanges();
            return this.movies.GetById(model.Id);
        }
    }
}
