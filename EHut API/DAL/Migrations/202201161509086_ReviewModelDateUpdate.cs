namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewModelDateUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopReviews", "Image", c => c.String(nullable:true));
            DropColumn("dbo.ShopReviews", "ImageForReview");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShopReviews", "ImageForReview", c => c.String());
            DropColumn("dbo.ShopReviews", "Image");
        }
    }
}
