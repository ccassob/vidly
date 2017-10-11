namespace Vidly.WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNewPropertiesToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Genre = c.String(),
                    DateAdded = c.DateTime(nullable: false),
                    Stock = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}