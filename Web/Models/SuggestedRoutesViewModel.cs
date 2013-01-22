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
        public Climb BestClimb { get; set; }
        public List<Route> SuggestedRoutes { get; set; }
    }
}