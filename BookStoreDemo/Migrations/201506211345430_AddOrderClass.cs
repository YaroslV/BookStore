namespace BookStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Books", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Books", "Order_OrderId");
            AddForeignKey("dbo.Books", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Books", new[] { "Order_OrderId" });
            DropColumn("dbo.Books", "Order_OrderId");
            DropTable("dbo.Orders");
        }
    }
}
