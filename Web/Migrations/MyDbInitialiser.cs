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
                new Color { Name = "Red", Hex = "FF0000" },
                new Color { Name = "Green", Hex = "00FF00" },
                new Color { Name = "Blue", Hex = "0000FF" });

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
        }
    }
}