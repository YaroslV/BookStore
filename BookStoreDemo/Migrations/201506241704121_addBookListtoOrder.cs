namespace BookStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBookListtoOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Books", "Order_OrderId");
            AddForeignKey("dbo.Books", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Books", new[] { "Order_OrderId" });
            DropColumn("dbo.Books", "Order_OrderId");
        }
    }
}
