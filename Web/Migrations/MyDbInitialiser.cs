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

            context.ClimbTypes.AddOrUpdate(g => g.Name,
                new ClimbType { Name = "Top Rope" },
                new ClimbType { Name = "Lead" },
                new ClimbType { Name = "Bouldering" });

            context.Colors.AddOrUpdate(c => c.Name,
                new Color { Name = "Black", Hex = "000000" },
                new Color { Name = "Blue", Hex = "0000FF" },
                new Color { Name = "Flo Yellow", Hex = "#F3F781" },
                new Color { Name = "Green", Hex = "00FF00" },
                new Color { Name = "Orange", Hex = "FFA500" },
                new Color { Name = "Pink", Hex = "FF1493" },
                new Color { Name = "Purple", Hex = "800080" },
                new Color { Name = "Red", Hex = "FF0000" },
                new Color { Name = "Yellow", Hex = "FFFF00" },
                new Color { Name = "White", Hex = "FFFFFF" });
                

            context.Grades.AddOrUpdate(g => g.Name,
               new Grade { Name = "1" },
               new Grade { Name = "2" },
               new Grade { Name = "3" },
               new Grade { Name = "4" },
               new Grade { Name = "4+" },
               new Grade { Name = "5" },
               new Grade { Name = "5+" },
               new Grade { Name = "6a" },
               new Grade { Name = "6b" },
               new Grade { Name = "5c" });

            context.Locations.AddOrUpdate(l => l.Name,
                new Location { Name = "Awesome Walls Dublin", AddedBy = context.Users.Single(u => u.UserName == "admin") });
        }
    }
}