namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKRemovedCredential : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Admins");
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Customers");
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Managers");
            DropIndex("dbo.Credentials", new[] { "UserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Credentials", "UserId");
            AddForeignKey("dbo.Credentials", "UserId", "dbo.Managers", "ManagerId", cascadeDelete: true);
            AddForeignKey("dbo.Credentials", "UserId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Credentials", "UserId", "dbo.Admins", "AdminId", cascadeDelete: true);
        }
    }
}
