namespace Movies.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSomeClasses : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SomeClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SomeClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
