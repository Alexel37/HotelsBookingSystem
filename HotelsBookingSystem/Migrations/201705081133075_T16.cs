namespace HotelsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingHistories", "CreditCardId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingHistories", "CreditCardId");
        }
    }
}
