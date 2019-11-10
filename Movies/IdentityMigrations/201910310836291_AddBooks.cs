namespace Movies.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AudioBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AudioBooks");
        }
    }
}
