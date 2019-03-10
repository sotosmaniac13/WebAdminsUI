namespace WebAdminsUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        CompletedByAnalyst = c.Boolean(nullable: false),
                        CompletedByArchitect = c.Boolean(nullable: false),
                        CompletedByProgrammer = c.Boolean(nullable: false),
                        CompletedByTester = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActionId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        Description = c.String(),
                        ActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Actions", t => t.ActionId, cascadeDelete: true)
                .Index(t => t.ActionId);
            
            DropColumn("dbo.AspNetUsers", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.Int(nullable: false));
            DropForeignKey("dbo.Documents", "ActionId", "dbo.Actions");
            DropIndex("dbo.Documents", new[] { "ActionId" });
            DropTable("dbo.Documents");
            DropTable("dbo.Actions");
        }
    }
}
