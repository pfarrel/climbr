using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    [Table("Climbs")]
    public class Climb
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Route Route { get; set; }
        public bool Succeeded { get; set; }
        public User Climber { get; set; }
    }
}