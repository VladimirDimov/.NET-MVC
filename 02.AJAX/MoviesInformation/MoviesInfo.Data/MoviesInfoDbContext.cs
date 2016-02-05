using MoviesInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Data
{
    public class MoviesInfoDbContext : DbContext
    {
        public MoviesInfoDbContext()
            : base("MoviesInfo")
        {
        }

        public virtual IDbSet<Movie> Movies { get; set; }
        public virtual IDbSet<Person> People { get; set; }
        public virtual IDbSet<Studio> Studios { get; set; }

        public static MoviesInfoDbContext Create()
        {
            return new MoviesInfoDbContext();
        }
    }
}
