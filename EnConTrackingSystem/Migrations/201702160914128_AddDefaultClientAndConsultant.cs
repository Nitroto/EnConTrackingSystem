namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultClientAndConsultant : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Clients (Id, Name) VALUES (1, 'No Clien')");
            Sql("INSERT INTO Consultants (Id, Name) VALUES (1, 'No Consultan')");
        }
        
        public override void Down()
        {
        }
    }
}
