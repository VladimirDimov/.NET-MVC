namespace MoviesInformation.Models.Movies
{
    using Microsoft.Ajax.Utilities;
    using MoviesInfo.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class MovieDetailsView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int LeadingMaleRoleId { get; set; }

        public string LeadingMaleRoleName { get; set; }

        public int LeadingFemaleRoleId { get; set; }

        public string LeadingFemaleRoleName { get; set; }

        public int DirectorId { get; set; }

        public string DirectorName { get; set; }

        public int StudioId { get; set; }

        public string StudioName { get; set; }

        public static Expression<Func<Movie, MovieDetailsView>> FromModel
        {
            get
            {
                return m => GetFromModel(m);
            }
        }

        public static MovieDetailsView GetFromModel(Movie m)
        {
            return new MovieDetailsView
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                DirectorId = m.DirectorId,
                DirectorName = m.Director.FirstName + " " + m.Director.LastName,
                LeadingFemaleRoleId = (int)m.LeadingFemaleRoleId,
                LeadingFemaleRoleName = $"{m.LeadingFemaleRole.FirstName} {m.LeadingFemaleRole.LastName}",
                LeadingMaleRoleId = (int)m.LeadingMaleRoleId,
                LeadingMaleRoleName = $"{m.LeadingMaleRole.FirstName} {m.LeadingMaleRole.LastName}"
            };
        }
    }
}