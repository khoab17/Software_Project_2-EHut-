namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopReviews", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.ShopReviews", "Ratting", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShopReviews", "Ratting");
            DropColumn("dbo.ShopReviews", "ProductId");
        }
    }
}
