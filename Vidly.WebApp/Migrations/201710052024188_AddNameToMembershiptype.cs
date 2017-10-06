namespace Vidly.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershiptype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "Name");
        }
    }
}
