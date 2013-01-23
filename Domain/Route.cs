using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Domain
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
        [Display(Name = "Grade")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [Required]
        [Display(Name = "Default Climb Type")]
        public int DefaultClimbTypeId { get; set; }
        [Display(Name = "Default Climb Type")]
        public virtual ClimbType DefaultClimbType { get; set; }

        [Display(Name = "Color")]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        [Required]
        [Display(Name = "Added By")]
        public int AddedById { get; set; }
        public virtual User AddedBy { get; set; }

        public virtual List<Climb> Climbs { get; set; }
    }

    public static class RouteObjectSetExtensions
    {
        // "Pointer" math on the grade Ids! Here be dragons.
        public static IOrderedQueryable<Route> OrderByClosestToGrade(this IQueryable<Route> routes, Grade grade)
        {
            var orderedRoutes = routes.OrderBy(r => Math.Abs(r.GradeId - grade.Id));
            return orderedRoutes;
        }

        public static IOrderedQueryable<Route> OrderByDifficulty(this IQueryable<Route> routes)
        {
            var orderedRoutes = routes.OrderBy(r => r.GradeId);
            return orderedRoutes;
        }
    }
}