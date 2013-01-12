using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Hex { get; set; }

        public virtual List<Route> Routes { get; set; }
    }
}