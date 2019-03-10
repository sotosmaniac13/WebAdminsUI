namespace WebAdminsUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "ActionId", "dbo.Actions");
            DropIndex("dbo.Documents", new[] { "ActionId" });
            AddColumn("dbo.Documents", "CompletedByAnalyst", c => c.Boolean(nullable: false));
            AddColumn("dbo.Documents", "CompletedByArchitect", c => c.Boolean(nullable: false));
            AddColumn("dbo.Documents", "CompletedByProgrammer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Documents", "CompletedByTester", c => c.Boolean(nullable: false));
            DropColumn("dbo.Documents", "ActionId");
            DropTable("dbo.Actions");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Documents", "ActionId", c => c.Int(nullable: false));
            DropColumn("dbo.Documents", "CompletedByTester");
            DropColumn("dbo.Documents", "CompletedByProgrammer");
            DropColumn("dbo.Documents", "CompletedByArchitect");
            DropColumn("dbo.Documents", "CompletedByAnalyst");
            CreateIndex("dbo.Documents", "ActionId");
            AddForeignKey("dbo.Documents", "ActionId", "dbo.Actions", "ActionId", cascadeDelete: true);
        }
    }
}
