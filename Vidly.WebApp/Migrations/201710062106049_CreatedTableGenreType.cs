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

            Sql("INSERT INTO dbo.GenreTypes (Name) VALUES ('Comedy')");
            Sql("INSERT INTO dbo.GenreTypes (Name) VALUES ('Action')");
            Sql("INSERT INTO dbo.GenreTypes (Name) VALUES ('Romance')");
            Sql("INSERT INTO dbo.GenreTypes (Name) VALUES ('Family')");

            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropTable("dbo.GenreTypes");
        }
    }
}
