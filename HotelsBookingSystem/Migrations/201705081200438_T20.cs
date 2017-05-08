namespace HotelsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingHistories", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingHistories", "Price");
        }
    }
}
