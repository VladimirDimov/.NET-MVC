using System.ComponentModel.DataAnnotations;

namespace MoviesInfo.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public City City { get; set; }

        public Street Street { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }
    }
}