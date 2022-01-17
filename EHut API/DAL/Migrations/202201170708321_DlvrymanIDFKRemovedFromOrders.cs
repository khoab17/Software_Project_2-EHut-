namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DlvrymanIDFKRemovedFromOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DeliverymanId", "dbo.Deliverymen");
            DropIndex("dbo.Orders", new[] { "DeliverymanId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Orders", "DeliverymanId");
            AddForeignKey("dbo.Orders", "DeliverymanId", "dbo.Deliverymen", "DeliveryManId", cascadeDelete: true);
        }
    }
}
