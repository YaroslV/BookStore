namespace BookStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderCountryAndCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Books", new[] { "Order_OrderId" });
            AddColumn("dbo.Orders", "OrderCountry", c => c.String());
            AddColumn("dbo.Orders", "OrderCity", c => c.String());
            DropColumn("dbo.Books", "Order_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Order_OrderId", c => c.Int());
            DropColumn("dbo.Orders", "OrderCity");
            DropColumn("dbo.Orders", "OrderCountry");
            CreateIndex("dbo.Books", "Order_OrderId");
            AddForeignKey("dbo.Books", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
