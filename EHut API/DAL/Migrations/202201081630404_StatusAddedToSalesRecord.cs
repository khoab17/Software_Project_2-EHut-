namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusAddedToSalesRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesRecords", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesRecords", "Status");
        }
    }
}
