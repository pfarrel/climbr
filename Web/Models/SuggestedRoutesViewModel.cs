using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Models
{
    public class SuggestedRoutesViewModel
    {
        [Display(Name = "Best Climb")]
        public Climb BestClimb { get; set; }
        
        [Display(Name = "Suggested Routes")]
        [UIHint("RouteList")]
        public List<Route> SuggestedRoutes { get; set; }
    }
}