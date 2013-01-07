namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Routes", "Grade_Id", c => c.Int());
            AddForeignKey("dbo.Routes", "Grade_Id", "dbo.Grades", "Id");
            CreateIndex("dbo.Routes", "Grade_Id");
            DropColumn("dbo.Routes", "Grade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "Grade", c => c.String());
            DropIndex("dbo.Routes", new[] { "Grade_Id" });
            DropForeignKey("dbo.Routes", "Grade_Id", "dbo.Grades");
            DropColumn("dbo.Routes", "Grade_Id");
            DropTable("dbo.Grades");
        }
    }
}
