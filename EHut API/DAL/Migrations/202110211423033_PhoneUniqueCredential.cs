namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneUniqueCredential : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Credentials", "Phone", c => c.String(maxLength: 50));
            CreateIndex("dbo.Credentials", "Phone", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Credentials", new[] { "Phone" });
            AlterColumn("dbo.Credentials", "Phone", c => c.String());
        }
    }
}
