namespace Vidly.WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNewPropertiesForIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Position", c => c.String(maxLength: 20));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Position");
        }
    }
}