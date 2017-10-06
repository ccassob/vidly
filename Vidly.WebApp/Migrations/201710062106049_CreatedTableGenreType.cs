namespace Vidly.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTableGenreType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);

            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropTable("dbo.GenreTypes");
        }
    }
}
