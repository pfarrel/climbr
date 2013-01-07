namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Grade = c.String(),
                        Location_Id = c.Int(),
                        AddedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.Users", t => t.AddedBy_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.AddedBy_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AddedBy_Id)
                .Index(t => t.AddedBy_Id);
            
            CreateTable(
                "dbo.Climbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Succeeded = c.Boolean(nullable: false),
                        Route_Id = c.Int(),
                        Climber_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .ForeignKey("dbo.Users", t => t.Climber_Id)
                .Index(t => t.Route_Id)
                .Index(t => t.Climber_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Climbs", new[] { "Climber_Id" });
            DropIndex("dbo.Climbs", new[] { "Route_Id" });
            DropIndex("dbo.Locations", new[] { "AddedBy_Id" });
            DropIndex("dbo.Routes", new[] { "AddedBy_Id" });
            DropIndex("dbo.Routes", new[] { "Location_Id" });
            DropForeignKey("dbo.Climbs", "Climber_Id", "dbo.Users");
            DropForeignKey("dbo.Climbs", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.Locations", "AddedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Routes", "AddedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Routes", "Location_Id", "dbo.Locations");
            DropTable("dbo.Climbs");
            DropTable("dbo.Locations");
            DropTable("dbo.Routes");
            DropTable("dbo.Users");
        }
    }
}
