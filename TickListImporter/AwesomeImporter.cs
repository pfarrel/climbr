using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace TickListImporter
{
    public class AwesomeImporter
    {
        public static IEnumerable<Route> Import(string filename, ClimbrContext context)
        {
            var excel = new ExcelQueryFactory(filename);
            var sheetRoutes = excel.Worksheet<SheetRoute>()
                .Where(r => r.Grade != "#REF!" && r.Grade != null)
                .ToList();

            for (int i = 1; i < sheetRoutes.Count; i++)
            {
                if (sheetRoutes[i].Line == null || sheetRoutes[i].Line == "#REF!")
                {
                    sheetRoutes[i].Line = sheetRoutes[i - 1].Line;
                }
            }

            var routes = sheetRoutes.Select(
                sr => new Route
                {
                    Color = context.Colors.Single(c => c.Name.Equals(sr.Colour, StringComparison.InvariantCultureIgnoreCase)),
                    Grade = context.Grades.Single(g => g.Name.Equals(sr.Grade, StringComparison.InvariantCultureIgnoreCase)),
                    Name = sr.Line
                })
                .ToList();

            return routes;
        }
    }
}
