using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using Web.Models;

namespace Web.Migrations
{
    public class MyDbInitialiser : DropCreateDatabaseAlways<ClimbrContext>
    {
        protected override void Seed(Web.Models.ClimbrContext context)
        {
            base.Seed(context);

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection",
                    "Users",
                    "Id",
                    "UserName",
                    autoCreateTables: true);
            }

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("admin"))
                WebSecurity.CreateUserAndAccount("admin", "password");

            if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });

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

            context.ClimbTypes.AddOrUpdate(g => g.Name,
                new ClimbType { Name = "Top Rope" },
                new ClimbType { Name = "Lead" },
                new ClimbType { Name = "Bouldering" });

            context.SaveChanges();
        }
    }
}