using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    [Table("Routes")]
    public class Route
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        [Required]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [Required]
        public int DefaultClimbTypeId { get; set; }
        public virtual ClimbType DefaultClimbType { get; set; }

        [Required]
        [Display(Name = "Added By")]
        public int AddedById { get; set; }
        public virtual User AddedBy { get; set; }
    }
}