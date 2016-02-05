using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesInfo.Models
{
    public class Country
    {
        private ICollection<City> cities;
        private ICollection<Address> address;

        public Country()
        {
            this.cities = new HashSet<City>();
            this.address = new HashSet<Address>();
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

        public virtual ICollection<Address> Addresses
        {
            get { return this.address; }
            set { this.address = value; }
        }
    }
}