namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfBirth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.String(nullable: true));

        }

        public override void Down()
        {
        }
    }
}
