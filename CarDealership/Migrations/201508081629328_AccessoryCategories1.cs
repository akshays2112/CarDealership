namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessoryCategories1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccessoryCategories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccessoryCategories", "Name", c => c.Int(nullable: false));
        }
    }
}
