using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesInfo.Models
{
    public class Street
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}