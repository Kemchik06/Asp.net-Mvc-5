namespace Movies.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelteGeneeIdFromMOvies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Short(nullable: false));
            DropColumn("dbo.Movies", "Genre");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
