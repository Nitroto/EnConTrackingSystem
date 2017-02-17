namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextBulshit1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Projects", new[] { "ProgramId" });
            AlterColumn("dbo.Projects", "ProgramId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "ProgramId");
            AddForeignKey("dbo.Projects", "ProgramId", "dbo.Programs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Projects", new[] { "ProgramId" });
            AlterColumn("dbo.Projects", "ProgramId", c => c.Int());
            CreateIndex("dbo.Projects", "ProgramId");
            AddForeignKey("dbo.Projects", "ProgramId", "dbo.Programs", "Id");
        }
    }
}
