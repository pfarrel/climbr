using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using Web.Models;

namespace Web.Migrations
{
    public class MyDbInitialiser : DropCreateDatabaseIfModelChanges<ClimbrContext>
    {
        protected override void Seed(Web.Models.ClimbrContext context)
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection",
                    "Users",
                    "Id",
                    "UserName",
                    autoCreateTables: true);
            }

            if (!WebSecurity.UserExists("admin"))
                WebSecurity.CreateUserAndAccount("admin", "password");

            var admin = context.Users.Single(u => u.UserName == "admin").Id;

            context.ClimbTypes.AddOrUpdate(
                ct => ct.Id,
                new ClimbType { Id = 1, Name = "Top Rope" },
                new ClimbType { Id = 2, Name = "Lead" },
                new ClimbType { Id = 3, Name = "Bouldering" });

            context.Colors.AddOrUpdate(
                c => c.Id,
                new Color { Id = 1, Name = "Black", Hex = "000000" },
                new Color { Id = 2, Name = "Blue", Hex = "0000FF" },
                new Color { Id = 3, Name = "Flo Yellow", Hex = "F3F781" },
                new Color { Id = 4, Name = "Green", Hex = "00FF00" },
                new Color { Id = 5, Name = "Orange", Hex = "FFA500" },
                new Color { Id = 6, Name = "Pink", Hex = "FF1493" },
                new Color { Id = 7, Name = "Purple", Hex = "800080" },
                new Color { Id = 8, Name = "Red", Hex = "FF0000" },
                new Color { Id = 9, Name = "Yellow", Hex = "FFFF00" },
                new Color { Id = 10, Name = "White", Hex = "FFFFFF" });

            context.Grades.AddOrUpdate(
                g => g.Id,
                new Grade { Id = 1, Name = "3" },
                new Grade { Id = 2, Name = "4" },
                new Grade { Id = 3, Name = "4+" },
                new Grade { Id = 4, Name = "5" },
                new Grade { Id = 5, Name = "5+" },
                new Grade { Id = 6, Name = "6a" },
                new Grade { Id = 7, Name = "6b" },
                new Grade { Id = 8, Name = "5c" });

            context.Locations.AddOrUpdate(
                l => l.Id,
                new Location { Id = 1, Name = "Awesome Walls Dublin", AddedById = admin });
            
            context.Routes.AddOrUpdate(
                r => r.Id,
                new Route { Id = 1, AddedById = admin, ColorId = 1, DefaultClimbTypeId = 1, GradeId = 1, LocationId = 1, Name = "1" },
                new Route { Id = 2, AddedById = admin, ColorId = 2, DefaultClimbTypeId = 2, GradeId = 2, LocationId = 1, Name = "1" },
                new Route { Id = 3, AddedById = admin, ColorId = 3, DefaultClimbTypeId = 1, GradeId = 3, LocationId = 1, Name = "1" },
                new Route { Id = 4, AddedById = admin, ColorId = 4, DefaultClimbTypeId = 2, GradeId = 4, LocationId = 1, Name = "2" },
                new Route { Id = 5, AddedById = admin, ColorId = 5, DefaultClimbTypeId = 1, GradeId = 5, LocationId = 1, Name = "2" },
                new Route { Id = 6, AddedById = admin, ColorId = 6, DefaultClimbTypeId = 2, GradeId = 6, LocationId = 1, Name = "2" },
                new Route { Id = 7, AddedById = admin, ColorId = 7, DefaultClimbTypeId = 2, GradeId = 7, LocationId = 1, Name = "2" },
                new Route { Id = 8, AddedById = admin, ColorId = 8, DefaultClimbTypeId = 1, GradeId = 8, LocationId = 1, Name = "3" },
                new Route { Id = 9, AddedById = admin, ColorId = 9, DefaultClimbTypeId = 2, GradeId = 1, LocationId = 1, Name = "4" },
                new Route { Id = 10, AddedById = admin, ColorId = 10, DefaultClimbTypeId = 2, GradeId = 2, LocationId = 1, Name = "4" });
        }
    }
}