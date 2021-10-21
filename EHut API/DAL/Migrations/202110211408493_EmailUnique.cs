namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Shops", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Deliverymen", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Managers", "Email", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Admins", "Email", unique: true);
            CreateIndex("dbo.Shops", "Email", unique: true);
            CreateIndex("dbo.Customers", "Email", unique: true);
            CreateIndex("dbo.Deliverymen", "Email", unique: true);
            CreateIndex("dbo.Managers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Managers", new[] { "Email" });
            DropIndex("dbo.Deliverymen", new[] { "Email" });
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Shops", new[] { "Email" });
            DropIndex("dbo.Admins", new[] { "Email" });
            AlterColumn("dbo.Managers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Deliverymen", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Shops", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
        }
    }
}
