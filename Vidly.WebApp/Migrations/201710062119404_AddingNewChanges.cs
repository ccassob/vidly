namespace Vidly.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNewChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
    }
}
