namespace Movies.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.MembershipTypes");
            CreateTable(
                "dbo.SomeClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Genres", "Id", c => c.Short(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Short(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Short(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DiscountRate", c => c.Short(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Short(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Short(nullable: false));
            AlterColumn("dbo.Movies", "NumberAvailable", c => c.Short(nullable: false));
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddPrimaryKey("dbo.Genres", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
            DropTable("dbo.SomeClasses");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
