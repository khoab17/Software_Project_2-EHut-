namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesRecordStatusChangedToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesRecords", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesRecords", "Status", c => c.Boolean(nullable: false));
        }
    }
}
