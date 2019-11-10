namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'16f0e818-4d50-47d2-9873-55a89c58969f', N'guest@vidly.com', 0, N'AKZ3UrWTrnzhFXrFUZWXxMfHzocSIcsYunmJ8l0xjN4g1CYN0lr54+MPxFednGRwHQ==', N'ef047cd5-369d-4fa2-b420-db62dc0a5ce4', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d1ba617-39aa-46e0-b038-ae74404133d7', N'admin@vidly.com', 0, N'AM8tj9P/WvJXWaBX5KW7EImGatR0k0a1ttqbPaivc8c4L2TYb9jPwfhpUXce1Nz8xg==', N'6cdc10e1-d18b-4385-af8c-ed49706f1ea9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'762a9727-4c87-47f4-96eb-186d11816e46', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d1ba617-39aa-46e0-b038-ae74404133d7', N'762a9727-4c87-47f4-96eb-186d11816e46')

");
        }
        
        public override void Down()
        {
        }
    }
}
