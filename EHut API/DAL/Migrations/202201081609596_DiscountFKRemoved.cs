namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountFKRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discounts", "ProviderId", "dbo.Managers");
            DropForeignKey("dbo.Discounts", "ProviderId", "dbo.Shops");
            DropIndex("dbo.Discounts", new[] { "ProviderId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Discounts", "ProviderId");
            AddForeignKey("dbo.Discounts", "ProviderId", "dbo.Shops", "ShopId", cascadeDelete: true);
            AddForeignKey("dbo.Discounts", "ProviderId", "dbo.Managers", "ManagerId", cascadeDelete: true);
        }
    }
}
