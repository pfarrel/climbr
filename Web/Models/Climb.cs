﻿using System;
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

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        [Required]
        public bool Succeeded { get; set; }

        [Required]
        public int ClimberId { get; set; }
        public virtual User Climber { get; set; }

        public Climb()
        {
            Date = DateTime.Now;
        }
    }
}