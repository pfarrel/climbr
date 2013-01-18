using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace TickListImporter.Test
{
    [TestClass]
    public class AwesomeImporterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new ClimbrContext())
            {
                var routes = AwesomeImporter.Import("Resources\\AwesomeTickList.xlsx", context);

                var admin = context.Users.Single(u => u.UserName == "admin").Id;
                var location = context.Locations.First().Id;
                var lead = context.ClimbTypes.Single(ct => ct.Name == "Lead").Id;

                foreach (var route in routes)
                {
                    route.AddedById = admin;
                    route.LocationId =location;
                    route.DefaultClimbTypeId = lead;
                    context.Routes.Add(route);
                }
                var a = 1;
                context.SaveChanges();
            }
        }
    }
}
