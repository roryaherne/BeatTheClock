namespace BeatTheClock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        OrderedById = c.String(nullable: false, maxLength: 128),
                        PlaceId = c.Int(nullable: false),
                        OrderStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.OrderedById, cascadeDelete: false)
                .ForeignKey("dbo.OrderStates", t => t.OrderStateId, cascadeDelete: false)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.UnitId)
                .Index(t => t.OrderedById)
                .Index(t => t.PlaceId)
                .Index(t => t.OrderStateId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.OrderStates",
                c => new
                    {
                        OrderStateId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 512),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderStateId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        DateCreated = c.DateTime(nullable: false),
                        Capacity = c.Int(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PlaceId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 512),
                        ExperationPeriod = c.Int(nullable: false),
                        Image = c.Binary(),
                        DateCreated = c.DateTime(nullable: false),
                        StockUnitId = c.Int(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        ProductStateId = c.Int(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                        Unit_UnitId = c.Int(),
                        Unit_UnitId1 = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .ForeignKey("dbo.ProductStates", t => t.ProductStateId, cascadeDelete: false)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Units", t => t.Unit_UnitId)
                .ForeignKey("dbo.Units", t => t.Unit_UnitId1)
                .ForeignKey("dbo.Units", t => t.StockUnitId, cascadeDelete: false)
                .Index(t => t.StockUnitId)
                .Index(t => t.CreatedById)
                .Index(t => t.ProductStateId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.Unit_UnitId)
                .Index(t => t.Unit_UnitId1);
            
            CreateTable(
                "dbo.ProductStates",
                c => new
                    {
                        ProductStateId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 512),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductStateId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 512),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductTypeId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ShortName = c.String(maxLength: 128),
                        Description = c.String(),
                        BasisFactor = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.CreatedById)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Expires = c.DateTime(nullable: false),
                        Delivered = c.DateTime(nullable: false),
                        PurchPrice = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "StockUnitId", "dbo.Units");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Units", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Unit_UnitId1", "dbo.Units");
            DropForeignKey("dbo.Products", "Unit_UnitId", "dbo.Units");
            DropForeignKey("dbo.Orders", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Units", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductTypes", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ProductStateId", "dbo.ProductStates");
            DropForeignKey("dbo.ProductStates", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Places", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "OrderStateId", "dbo.OrderStates");
            DropForeignKey("dbo.OrderStates", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "OrderedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Stocks", new[] { "CreatedById" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Units", new[] { "Product_ProductId" });
            DropIndex("dbo.Units", new[] { "CreatedById" });
            DropIndex("dbo.ProductTypes", new[] { "CreatedById" });
            DropIndex("dbo.ProductStates", new[] { "CreatedById" });
            DropIndex("dbo.Products", new[] { "Unit_UnitId1" });
            DropIndex("dbo.Products", new[] { "Unit_UnitId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.Products", new[] { "ProductStateId" });
            DropIndex("dbo.Products", new[] { "CreatedById" });
            DropIndex("dbo.Products", new[] { "StockUnitId" });
            DropIndex("dbo.Places", new[] { "CreatedById" });
            DropIndex("dbo.OrderStates", new[] { "CreatedById" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "OrderStateId" });
            DropIndex("dbo.Orders", new[] { "PlaceId" });
            DropIndex("dbo.Orders", new[] { "OrderedById" });
            DropIndex("dbo.Orders", new[] { "UnitId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Stocks");
            DropTable("dbo.Units");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductStates");
            DropTable("dbo.Products");
            DropTable("dbo.Places");
            DropTable("dbo.OrderStates");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
        }
    }
}
