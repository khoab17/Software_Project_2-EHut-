namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.BankInformations",
                c => new
                    {
                        BankInformationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AccountHolderName = c.String(nullable: false),
                        AccountNumber = c.String(nullable: false),
                        BranchName = c.String(nullable: false),
                        RoutingNumber = c.String(nullable: false),
                        ChequeBookImage = c.String(),
                    })
                .PrimaryKey(t => t.BankInformationId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        BrandId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Details = c.String(),
                        Warranty = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductDistributions",
                c => new
                    {
                        ProductDistributionId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDistributionId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ShopManager = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BankInformationId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                        TotalSold = c.Double(nullable: false),
                        TotalRecievedPayment = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ShopId)
                .ForeignKey("dbo.BankInformations", t => t.BankInformationId, cascadeDelete: true)
                .Index(t => t.BankInformationId);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        CredentialId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Phone = c.String(),
                        Role = c.String(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CredentialId)
                .ForeignKey("dbo.Admins", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Occupation = c.String(nullable: false, maxLength: 50),
                        NumberOfFamilyMemberAdult = c.Int(nullable: false),
                        NumberOfFamilyMemberChild = c.Int(nullable: false),
                        NumberOfDeliveryGrocery = c.Int(nullable: false),
                        NumberOfDeliveryVegitables = c.Int(nullable: false),
                        DeliveryDay = c.String(nullable: false),
                        DeliveryTime = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        ManagerialRole = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            CreateTable(
                "dbo.Deliverymen",
                c => new
                    {
                        DeliveryManId = c.Int(nullable: false, identity: true),
                        Nid = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Rating = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.DeliveryManId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountId)
                .ForeignKey("dbo.Managers", t => t.ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageSource = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.MonthlyExpenditures",
                c => new
                    {
                        MonthlyExpenditureId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Minimum = c.Double(nullable: false),
                        Maximum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MonthlyExpenditureId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AddedSubtotal = c.Double(nullable: false),
                        DiscountId = c.Int(nullable: false),
                        GrandTotal = c.Double(nullable: false),
                        DeliverymanId = c.Int(nullable: false),
                        DeliveryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Deliverymen", t => t.DeliverymanId, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.DiscountId)
                .Index(t => t.DeliverymanId);
            
            CreateTable(
                "dbo.SalesRecords",
                c => new
                    {
                        SalesRecordId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Subtotal = c.Double(nullable: false),
                        ShopId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesRecordId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.ShopId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.ShopReviews",
                c => new
                    {
                        ShopReviewId = c.Int(nullable: false, identity: true),
                        ShopId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShopReviewId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopReviews", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ShopReviews", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesRecords", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.SalesRecords", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SalesRecords", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.SalesRecords", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.Orders", "DeliverymanId", "dbo.Deliverymen");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MonthlyExpenditures", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Discounts", "ProviderId", "dbo.Shops");
            DropForeignKey("dbo.Discounts", "ProviderId", "dbo.Managers");
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Managers");
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Customers");
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Admins");
            DropForeignKey("dbo.ProductDistributions", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Shops", "BankInformationId", "dbo.BankInformations");
            DropForeignKey("dbo.ProductDistributions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.ShopReviews", new[] { "CustomerId" });
            DropIndex("dbo.ShopReviews", new[] { "ShopId" });
            DropIndex("dbo.SalesRecords", new[] { "OrderId" });
            DropIndex("dbo.SalesRecords", new[] { "ShopId" });
            DropIndex("dbo.SalesRecords", new[] { "ProductId" });
            DropIndex("dbo.SalesRecords", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "DeliverymanId" });
            DropIndex("dbo.Orders", new[] { "DiscountId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.MonthlyExpenditures", new[] { "CustomerId" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Discounts", new[] { "ProviderId" });
            DropIndex("dbo.Credentials", new[] { "UserId" });
            DropIndex("dbo.Shops", new[] { "BankInformationId" });
            DropIndex("dbo.ProductDistributions", new[] { "ShopId" });
            DropIndex("dbo.ProductDistributions", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.ShopReviews");
            DropTable("dbo.SalesRecords");
            DropTable("dbo.Orders");
            DropTable("dbo.MonthlyExpenditures");
            DropTable("dbo.Images");
            DropTable("dbo.Discounts");
            DropTable("dbo.Deliverymen");
            DropTable("dbo.Managers");
            DropTable("dbo.Customers");
            DropTable("dbo.Credentials");
            DropTable("dbo.Shops");
            DropTable("dbo.ProductDistributions");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.BankInformations");
            DropTable("dbo.Admins");
        }
    }
}
