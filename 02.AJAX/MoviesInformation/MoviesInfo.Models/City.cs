using System.Collections.Generic;

namespace MoviesInfo.Models
{
    public class City
    {
        private ICollection<Street> streets;

        public City()
        {
            this.streets = new HashSet<Street>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Street> Streets
        {
            get { return this.streets; }
            set { this.streets = value; }
        }
    }
}