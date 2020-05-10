namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.Sales", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Sales", "Salesman_ID", "dbo.Salesmen");
            DropIndex("dbo.Sales", new[] { "Car_ID" });
            DropIndex("dbo.Sales", new[] { "Customer_ID" });
            DropIndex("dbo.Sales", new[] { "Salesman_ID" });
            RenameColumn(table: "dbo.Sales", name: "Car_ID", newName: "CarID");
            RenameColumn(table: "dbo.Sales", name: "Customer_ID", newName: "CustomerID");
            RenameColumn(table: "dbo.Sales", name: "Salesman_ID", newName: "SalesmanID");
            AlterColumn("dbo.Sales", "CarID", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "SalesmanID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "SalesmanID");
            CreateIndex("dbo.Sales", "CustomerID");
            CreateIndex("dbo.Sales", "CarID");
            AddForeignKey("dbo.Sales", "CarID", "dbo.Cars", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "SalesmanID", "dbo.Salesmen", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "SalesmanID", "dbo.Salesmen");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Sales", "CarID", "dbo.Cars");
            DropIndex("dbo.Sales", new[] { "CarID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.Sales", new[] { "SalesmanID" });
            AlterColumn("dbo.Sales", "SalesmanID", c => c.Int());
            AlterColumn("dbo.Sales", "CustomerID", c => c.Int());
            AlterColumn("dbo.Sales", "CarID", c => c.Int());
            RenameColumn(table: "dbo.Sales", name: "SalesmanID", newName: "Salesman_ID");
            RenameColumn(table: "dbo.Sales", name: "CustomerID", newName: "Customer_ID");
            RenameColumn(table: "dbo.Sales", name: "CarID", newName: "Car_ID");
            CreateIndex("dbo.Sales", "Salesman_ID");
            CreateIndex("dbo.Sales", "Customer_ID");
            CreateIndex("dbo.Sales", "Car_ID");
            AddForeignKey("dbo.Sales", "Salesman_ID", "dbo.Salesmen", "ID");
            AddForeignKey("dbo.Sales", "Customer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Sales", "Car_ID", "dbo.Cars", "ID");
        }
    }
}
