using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Converter.Models
{
    public class CalculatorRequestModel
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The minimum value for quantity is 0!")]
        public int Quantity { get; set; }

        [Required]
        public Units Type { get; set; }

        public int Kilo { get; set; }
    }
}