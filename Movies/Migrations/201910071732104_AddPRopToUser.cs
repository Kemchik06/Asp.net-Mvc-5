namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPRopToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "IsSubscribedToNewsletter");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
