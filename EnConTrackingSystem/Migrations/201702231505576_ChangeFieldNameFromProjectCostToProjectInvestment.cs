namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldNameFromProjectCostToProjectInvestment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectInvestment", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Projects", "ProjectCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectCost", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Projects", "ProjectInvestment");
        }
    }
}
