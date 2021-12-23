namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedConstrainsFromCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "NumberOfFamilyMemberAdult", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NumberOfFamilyMemberAdult", c => c.Int(nullable: false));
        }
    }
}
