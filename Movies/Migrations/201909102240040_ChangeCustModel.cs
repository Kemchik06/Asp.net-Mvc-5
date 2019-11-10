namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.String());
        }
    }
}
