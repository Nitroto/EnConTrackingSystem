namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionInDbStructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Projects", "ConsultantId", "dbo.Consultants");
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropIndex("dbo.Projects", new[] { "ConsultantId" });
            AlterColumn("dbo.Clients", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.Clients", "Email", c => c.String(maxLength: 30));
            AlterColumn("dbo.Projects", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ConsultantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultants", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.Consultants", "Email", c => c.String(maxLength: 30));
            CreateIndex("dbo.Projects", "ClientId");
            CreateIndex("dbo.Projects", "ConsultantId");
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ConsultantId", "dbo.Consultants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ConsultantId" });
            DropIndex("dbo.Projects", new[] { "ClientId" });
            AlterColumn("dbo.Consultants", "Email", c => c.String());
            AlterColumn("dbo.Consultants", "Phone", c => c.String());
            AlterColumn("dbo.Projects", "ConsultantId", c => c.Int());
            AlterColumn("dbo.Projects", "ClientId", c => c.Int());
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "Phone", c => c.String());
            CreateIndex("dbo.Projects", "ConsultantId");
            CreateIndex("dbo.Projects", "ClientId");
            AddForeignKey("dbo.Projects", "ConsultantId", "dbo.Consultants", "Id");
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "Id");
        }
    }
}
