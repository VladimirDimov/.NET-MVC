using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Models
{
    public class Person
    {
        private ICollection<Movie> movies;

        public Person()
        {
            this.movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(1, 150)]
        public int Age { get; set; }

        [Required]
        public Genders Gender { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
