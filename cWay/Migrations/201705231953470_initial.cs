namespace cWay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        TruckId = c.Int(nullable: false, identity: true),
                        TruckColor = c.String(nullable: false),
                        TruckEngineHours = c.String(),
                        TruckSuspensionType = c.Int(nullable: false),
                        TruckMileage = c.Int(nullable: false),
                        TruckVin = c.String(),
                        TruckPrice = c.Int(nullable: false),
                        TruckDescription = c.String(),
                        TruckIsSold = c.Boolean(nullable: false),
                        TruckHas2Tanks = c.Boolean(nullable: false),
                        TruckTank1Size = c.Int(nullable: false),
                        TruckTank2Size = c.Int(nullable: false),
                        TruckBrakeCondition = c.Int(nullable: false),
                        TruckTireCondition = c.Long(nullable: false),
                        TruckHasSleeper = c.Boolean(nullable: false),
                        TruckIsListed = c.Boolean(nullable: false),
                        TruckDealerNotes = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        TruckDealerDateOfPurchase = c.DateTime(nullable: false),
                        TruckDealerFinalSalePrice = c.Int(),
                        TruckDealerImprovementCost = c.Int(nullable: false),
                        TruckDealerDateOfSale = c.DateTime(),
                        TruckDealerPurchaseCost = c.Int(nullable: false),
                        TruckCabStyle = c.String(),
                        TruckEngineModel = c.String(),
                        TruckMake = c.String(nullable: false),
                        TruckModel = c.String(nullable: false),
                        TruckYear = c.Int(nullable: false),
                        TruckTransmissionType = c.Int(nullable: false),
                        TruckVehicleType = c.String(),
                        TruckBrakeType = c.String(),
                        TruckTransmissionSpeeds = c.String(),
                        TruckWheelBaseInches = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TruckWheelSizeFront = c.Int(nullable: false),
                        TruckWheelSizeRear = c.Int(nullable: false),
                        TruckTurbo = c.Int(nullable: false),
                        TruckAxleConfiguration = c.Int(nullable: false),
                        TruckEngineMake = c.String(),
                    })
                .PrimaryKey(t => t.TruckId);
            
            CreateTable(
                "dbo.TruckImages",
                c => new
                    {
                        TruckImageID = c.Int(nullable: false, identity: true),
                        TruckID = c.Int(nullable: false),
                        TruckVin = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.TruckImageID)
                .ForeignKey("dbo.Trucks", t => t.TruckID, cascadeDelete: true)
                .Index(t => t.TruckID);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TruckImages", "TruckID", "dbo.Trucks");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TruckImages", new[] { "TruckID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TruckImages");
            DropTable("dbo.Trucks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
