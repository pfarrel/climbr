using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Domain
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual List<Climb> Climbs { get; set; }
        public virtual List<Route> AddedRoutes { get; set; }
        public virtual List<Location> AddedLocations { get; set; }
    }

}