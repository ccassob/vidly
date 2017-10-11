namespace Vidly.WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateNamesOfMembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name = 'Pay As You Go' WHERE DurationInMonths = 0");
            Sql("UPDATE MemberShipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("UPDATE MemberShipTypes SET Name = 'Trimester' WHERE DurationInMonths = 3");
            Sql("UPDATE MemberShipTypes SET Name = 'Annual' WHERE DurationInMonths = 12");
        }

        public override void Down()
        {
        }
    }
}