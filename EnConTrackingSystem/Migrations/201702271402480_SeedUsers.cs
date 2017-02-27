namespace EnConTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f156459e-9097-4cb5-904d-9b1a76d48e75', N'office@enconservices.com', 0, N'APPJZyQrVFt50NXOj2trCAz0qtI4TLjPY1L6CEV4R6bZ4XFsKPkJgipgW05h7M8qlw==', N'454d484d-3100-47d1-9072-a46ef5dfc909', NULL, 0, 0, NULL, 1, 0, N'office@enconservices.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'48fbec99-4167-459e-b4ec-5ea64ab18bc3', N'Administrator')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f156459e-9097-4cb5-904d-9b1a76d48e75', N'48fbec99-4167-459e-b4ec-5ea64ab18bc3')
");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id=N'f156459e-9097-4cb5-904d-9b1a76d48e75'");
            Sql("DELETE FROM [dbo].[AspNetRoles] WHERE Id=N'48fbec99-4167-459e-b4ec-5ea64ab18bc3'");

        }
    }
}
