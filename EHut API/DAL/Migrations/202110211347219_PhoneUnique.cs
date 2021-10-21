namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Shops", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Deliverymen", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Managers", "Phone", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Admins", "Phone", unique: true);
            CreateIndex("dbo.Shops", "Phone", unique: true);
            CreateIndex("dbo.Customers", "Phone", unique: true);
            CreateIndex("dbo.Deliverymen", "Phone", unique: true);
            CreateIndex("dbo.Managers", "Phone", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Managers", new[] { "Phone" });
            DropIndex("dbo.Deliverymen", new[] { "Phone" });
            DropIndex("dbo.Customers", new[] { "Phone" });
            DropIndex("dbo.Shops", new[] { "Phone" });
            DropIndex("dbo.Admins", new[] { "Phone" });
            AlterColumn("dbo.Managers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Deliverymen", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Shops", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Phone", c => c.String(nullable: false));
        }
    }
}
