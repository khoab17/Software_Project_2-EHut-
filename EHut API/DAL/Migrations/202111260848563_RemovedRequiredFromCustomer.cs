namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredFromCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Occupation", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "DeliveryDay", c => c.String());
            AlterColumn("dbo.Customers", "DeliveryTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DeliveryTime", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "DeliveryDay", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Occupation", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
