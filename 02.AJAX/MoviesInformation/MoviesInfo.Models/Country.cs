using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesInfo.Models
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }
    }
}