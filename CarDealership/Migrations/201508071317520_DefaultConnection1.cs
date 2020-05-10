namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultConnection1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Car_ID", c => c.Int());
            AddColumn("dbo.Sales", "Customer_ID", c => c.Int());
            AddColumn("dbo.Sales", "Salesman_ID", c => c.Int());
            CreateIndex("dbo.Sales", "Car_ID");
            CreateIndex("dbo.Sales", "Customer_ID");
            CreateIndex("dbo.Sales", "Salesman_ID");
            AddForeignKey("dbo.Sales", "Car_ID", "dbo.Cars", "ID");
            AddForeignKey("dbo.Sales", "Customer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Sales", "Salesman_ID", "dbo.Salesmen", "ID");
            DropColumn("dbo.Sales", "SalesmanID");
            DropColumn("dbo.Sales", "CustomerID");
            DropColumn("dbo.Sales", "CarID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "CarID", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "SalesmanID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sales", "Salesman_ID", "dbo.Salesmen");
            DropForeignKey("dbo.Sales", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Sales", "Car_ID", "dbo.Cars");
            DropIndex("dbo.Sales", new[] { "Salesman_ID" });
            DropIndex("dbo.Sales", new[] { "Customer_ID" });
            DropIndex("dbo.Sales", new[] { "Car_ID" });
            DropColumn("dbo.Sales", "Salesman_ID");
            DropColumn("dbo.Sales", "Customer_ID");
            DropColumn("dbo.Sales", "Car_ID");
        }
    }
}
