using MoviesInfo.Models;
using System.ComponentModel;

namespace MoviesInformation.Models.Movies
{
    public class MovieUpdateModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        [DisplayName("Leading male role")]
        public int LeadingMaleRoleId { get; set; }

        [DisplayName("Leading female role")]
        public int LeadingFemaleRoleId { get; set; }

        [DisplayName("Director")]
        public int DirectorId { get; set; }

        public int StudioId { get; set; }

        public static Movie ToModel(MovieUpdateModel model)
        {
            return new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Year = model.Year,
                LeadingMaleRoleId = model.LeadingMaleRoleId,
                LeadingFemaleRoleId = model.LeadingFemaleRoleId,
                DirectorId = model.DirectorId,
                StudioId = model.StudioId
            };
        }
    }
}