namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessoryCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessoryCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccessoryCategoryID = c.Int(nullable: false),
                        GroupName = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessoryCategories", t => t.AccessoryCategoryID, cascadeDelete: true)
                .Index(t => t.AccessoryCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "AccessoryCategoryID", "dbo.AccessoryCategories");
            DropIndex("dbo.Accessories", new[] { "AccessoryCategoryID" });
            DropTable("dbo.Accessories");
            DropTable("dbo.AccessoryCategories");
        }
    }
}
