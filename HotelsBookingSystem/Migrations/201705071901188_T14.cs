namespace HotelsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserLevelId", "dbo.UserLevels");
            DropIndex("dbo.AspNetUsers", new[] { "UserLevelId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AspNetUsers", "UserLevelId");
            AddForeignKey("dbo.AspNetUsers", "UserLevelId", "dbo.UserLevels", "Id", cascadeDelete: true);
        }
    }
}
