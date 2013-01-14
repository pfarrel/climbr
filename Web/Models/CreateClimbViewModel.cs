using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CreateClimbViewModel
    {
        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Route")]
        public int RouteId { get; set; }

        [Required]
        [Display(Name = "Climb Type")]
        public int ClimbTypeId { get; set; }

        [Required]
        [Range(1, 10)]
        public int Attempts { get; set; }

        [Required]
        public bool Succeeded { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}