namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Projects", "Consultant_Id", "dbo.Consultants");
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            DropIndex("dbo.Projects", new[] { "Consultant_Id" });
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Consultants");
            AlterColumn("dbo.Clients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Consultants", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "Client_Id", c => c.Int());
            AlterColumn("dbo.Projects", "Consultant_Id", c => c.Int());
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Consultants", "Id");
            CreateIndex("dbo.Projects", "Client_Id");
            CreateIndex("dbo.Projects", "Consultant_Id");
            AddForeignKey("dbo.Projects", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Projects", "Consultant_Id", "dbo.Consultants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "Consultant_Id" });
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            DropPrimaryKey("dbo.Consultants");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.Projects", "Consultant_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "Client_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Consultants", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clients", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Consultants", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            CreateIndex("dbo.Projects", "Consultant_Id");
            CreateIndex("dbo.Projects", "Client_Id");
            AddForeignKey("dbo.Projects", "Consultant_Id", "dbo.Consultants", "Id");
            AddForeignKey("dbo.Projects", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
