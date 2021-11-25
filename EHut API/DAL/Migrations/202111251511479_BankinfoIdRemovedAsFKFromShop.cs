namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankinfoIdRemovedAsFKFromShop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shops", "BankInformationId", "dbo.BankInformations");
            DropIndex("dbo.Shops", new[] { "BankInformationId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Shops", "BankInformationId");
            AddForeignKey("dbo.Shops", "BankInformationId", "dbo.BankInformations", "BankInformationId", cascadeDelete: true);
        }
    }
}
