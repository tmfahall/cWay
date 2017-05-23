namespace cWay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTruckImageTruckVintToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TruckImages", "TruckVin", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TruckImages", "TruckVin", c => c.Int(nullable: false));
        }
    }
}
