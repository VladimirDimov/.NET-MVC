using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Models
{
    public class Studio
    {
        private ICollection<Movie> moveies;

        public Studio()
        {
            this.moveies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.moveies; }
            set { this.moveies = value; }
        }
    }
}
