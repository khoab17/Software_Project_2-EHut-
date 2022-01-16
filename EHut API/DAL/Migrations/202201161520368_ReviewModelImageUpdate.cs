namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewModelImageUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopReviews", "ImageSource", c => c.String(nullable:true));
            DropColumn("dbo.ShopReviews", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShopReviews", "Image", c => c.String());
            DropColumn("dbo.ShopReviews", "ImageSource");
        }
    }
}
