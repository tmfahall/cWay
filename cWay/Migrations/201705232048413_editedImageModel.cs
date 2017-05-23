namespace cWay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedImageModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TruckImages", "TruckID", "dbo.Trucks");
            DropIndex("dbo.TruckImages", new[] { "TruckID" });
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageFileName = c.String(maxLength: 255),
                        TruckID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Trucks", t => t.TruckID, cascadeDelete: true)
                .Index(t => t.TruckID);
            
            DropTable("dbo.TruckImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TruckImages",
                c => new
                    {
                        TruckImageID = c.Int(nullable: false, identity: true),
                        TruckID = c.Int(nullable: false),
                        TruckVin = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.TruckImageID);
            
            DropForeignKey("dbo.Images", "TruckID", "dbo.Trucks");
            DropIndex("dbo.Images", new[] { "TruckID" });
            DropTable("dbo.Images");
            CreateIndex("dbo.TruckImages", "TruckID");
            AddForeignKey("dbo.TruckImages", "TruckID", "dbo.Trucks", "TruckId", cascadeDelete: true);
        }
    }
}
