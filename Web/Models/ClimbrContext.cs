using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ClimbrContext : DbContext
    {
        public ClimbrContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<User> UserProfiles { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Climb> Climbs { get; set; }
    }
}