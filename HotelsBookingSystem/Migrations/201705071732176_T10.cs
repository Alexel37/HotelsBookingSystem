namespace HotelsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserLevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserLevelId");
            AddForeignKey("dbo.AspNetUsers", "UserLevelId", "dbo.UserLevels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserLevelId", "dbo.UserLevels");
            DropIndex("dbo.AspNetUsers", new[] { "UserLevelId" });
            DropColumn("dbo.AspNetUsers", "UserLevelId");
            DropTable("dbo.UserLevels");
        }
    }
}
