namespace HotelsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T19 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookingHistories", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingHistories", "price", c => c.Int(nullable: false));
        }
    }
}
