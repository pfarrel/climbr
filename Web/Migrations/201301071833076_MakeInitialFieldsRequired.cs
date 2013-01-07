namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeInitialFieldsRequired : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Climbs", "IX_Route_Id");
            AlterColumn("dbo.Climbs", "Route_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Climbs", "Route_Id");

            AlterColumn("dbo.Routes", "Name", c => c.String(nullable: false));

            DropIndex("dbo.Routes", "IX_Grade_Id");
            AlterColumn("dbo.Routes", "Grade_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Routes", "Grade_Id");

            DropIndex("dbo.Routes", "IX_Location_Id");
            AlterColumn("dbo.Routes", "Location_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Routes", "Location_Id");

            DropIndex("dbo.Routes", "IX_AddedBy_Id");
            AlterColumn("dbo.Routes", "AddedBy_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Routes", "AddedBy_Id");

            AlterColumn("dbo.Grades", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "Name", c => c.String(nullable: false));

            DropIndex("dbo.Locations", "IX_AddedBy_Id");
            AlterColumn("dbo.Locations", "AddedBy_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "AddedBy_Id");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "AddedBy_Id", c => c.Int());
            AlterColumn("dbo.Locations", "Name", c => c.String());
            AlterColumn("dbo.Grades", "Name", c => c.String());
            AlterColumn("dbo.Routes", "AddedBy_Id", c => c.Int());
            AlterColumn("dbo.Routes", "Location_Id", c => c.Int());
            AlterColumn("dbo.Routes", "Grade_Id", c => c.Int());
            AlterColumn("dbo.Routes", "Name", c => c.String());
            AlterColumn("dbo.Climbs", "Route_Id", c => c.Int());
        }
    }
}
