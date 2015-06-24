namespace BookStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookNumberOfPages = c.Int(nullable: false),
                        BookAuthor_AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.BookAuthor_AuthorId)
                .Index(t => t.BookAuthor_AuthorId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookAuthor_AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "BookAuthor_AuthorId" });
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
        }
    }
}
