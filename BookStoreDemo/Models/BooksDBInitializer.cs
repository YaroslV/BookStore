using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStoreDemo.Models
{
    public class BooksDBInitializer : DropCreateDatabaseAlways<BookStoreDemoDBContext>
    {
        protected override void Seed(BookStoreDemoDBContext context)
        {            
            var Hemingway = new Author() { AuthorName = "Hemingway"} ;
            context.Books.Add(new Book() { BookName = "Fiesta", Price = 453, BookAuthor = Hemingway});
            context.Books.Add(new Book() { BookName = "Ulyssess", Price = 990, BookAuthor = new Author() { AuthorName = "Joyce" } });
            context.Books.Add(new Book() { BookName = "Plague", Price = 232, BookAuthor = new Author() { AuthorName = "Camus" } });
            context.Books.Add(new Book() { BookName = "Old and Sea", Price = 123, BookAuthor = Hemingway });
            
            base.Seed(context);
        }
    }
}