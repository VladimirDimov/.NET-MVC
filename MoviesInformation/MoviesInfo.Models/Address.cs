using System.ComponentModel.DataAnnotations;

namespace MoviesInfo.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public int StreetId { get; set; }

        public Street Street { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }
    }
}