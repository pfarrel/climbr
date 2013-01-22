using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public Climb HardestClimb { get; set; }
        public List<Climb> LastSessionClimbs { get; set; }
        public List<User> Friends { get; set; }
    }
}