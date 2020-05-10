namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleAccessories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleAccessories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SaleID = c.Int(nullable: false),
                        AccessoryID = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accessories", t => t.AccessoryID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.SaleID)
                .Index(t => t.AccessoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleAccessories", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.SaleAccessories", "AccessoryID", "dbo.Accessories");
            DropIndex("dbo.SaleAccessories", new[] { "AccessoryID" });
            DropIndex("dbo.SaleAccessories", new[] { "SaleID" });
            DropTable("dbo.SaleAccessories");
        }
    }
}
