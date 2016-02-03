﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Models
{
    public class Movie : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Range(1900, 2500)]
        public int Year { get; set; }

        public int LeadingMaleRoleId { get; set; }

        public virtual Person LeadingMaleRole { get; set; }

        public int LeadingFemaleRoleId { get; set; }

        public virtual Person LeadingFemaleRole { get; set; }

        public int DirectorId { get; set; }

        public virtual Person Director { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LeadingFemaleRole.Gender != Genders.Male)
            {
                yield return new ValidationResult("The leading male role must be a male person!");
            }

            if (LeadingFemaleRole.Gender != Genders.Female)
            {
                yield return new ValidationResult("The leading female role must be a female person!");
            }
        }
    }
}
