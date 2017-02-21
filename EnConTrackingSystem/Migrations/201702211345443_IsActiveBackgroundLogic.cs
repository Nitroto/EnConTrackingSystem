namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveBackgroundLogic : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Programs", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
