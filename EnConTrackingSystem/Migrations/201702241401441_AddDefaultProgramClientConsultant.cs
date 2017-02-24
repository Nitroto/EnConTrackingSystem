namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultProgramClientConsultant : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Programs (Name, StartDate) VALUES ('Regular Audits', '2005-01-01T00:00:00')");
            Sql("INSERT INTO Clients (Name) VALUES ('No Clien')");
            Sql("INSERT INTO Consultants (Name) VALUES ('No Consultan')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Programs WHERE Id=1");
            Sql("DELETE FROM Clients WHERE Id=1");
            Sql("DELETE FROM Consultants WHERE Id=1");
        }
    }
}
