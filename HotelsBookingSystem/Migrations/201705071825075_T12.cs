namespace HotelsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BookingHistories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CreditCards", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.BookingHistories", "ApplicationUserId");
            DropColumn("dbo.CreditCards", "ApplicationUserId");
            RenameColumn(table: "dbo.BookingHistories", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.CreditCards", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.BookingHistories", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CreditCards", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BookingHistories", "ApplicationUserId");
            CreateIndex("dbo.CreditCards", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditCards", new[] { "ApplicationUserId" });
            DropIndex("dbo.BookingHistories", new[] { "ApplicationUserId" });
            AlterColumn("dbo.CreditCards", "ApplicationUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookingHistories", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CreditCards", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.BookingHistories", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.CreditCards", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.BookingHistories", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditCards", "ApplicationUser_Id");
            CreateIndex("dbo.BookingHistories", "ApplicationUser_Id");
        }
    }
}
