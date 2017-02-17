namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextBulshit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "Program_Id", newName: "ProgramId");
            RenameColumn(table: "dbo.Projects", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Projects", name: "Consultant_Id", newName: "ConsultantId");
            RenameIndex(table: "dbo.Projects", name: "IX_Program_Id", newName: "IX_ProgramId");
            RenameIndex(table: "dbo.Projects", name: "IX_Client_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.Projects", name: "IX_Consultant_Id", newName: "IX_ConsultantId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_ConsultantId", newName: "IX_Consultant_Id");
            RenameIndex(table: "dbo.Projects", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameIndex(table: "dbo.Projects", name: "IX_ProgramId", newName: "IX_Program_Id");
            RenameColumn(table: "dbo.Projects", name: "ConsultantId", newName: "Consultant_Id");
            RenameColumn(table: "dbo.Projects", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "dbo.Projects", name: "ProgramId", newName: "Program_Id");
        }
    }
}
