namespace Movies.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Games", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Games", "Name", c => c.String());
        }
    }
}
