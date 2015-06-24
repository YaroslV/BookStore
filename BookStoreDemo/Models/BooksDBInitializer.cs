using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStoreDemo.Models
{
    public class BooksDBInitializer : CreateDatabaseIfNotExists<BookStoreDemoDBContext>
    {
        protected override void Seed(BookStoreDemoDBContext context)
        {

            context.Books.Add(new Book() { BookName = "Fiesta", BookNumberOfPages = 453, BookAuthor = new Author() { AuthorName = "Hemingway"} });
            context.Books.Add(new Book() { BookName = "Ulyssess", BookNumberOfPages = 990, BookAuthor = new Author() { AuthorName = "Joyce"} });
            context.Books.Add(new Book() { BookName = "Plague", BookNumberOfPages = 232, BookAuthor = new Author() { AuthorName = "Camus"} });
            context.Books.Add(new Book() { BookName = "Old and Sea", BookNumberOfPages = 123, BookAuthor = new Author() { AuthorName = "Hemingway"} });


            base.Seed(context);
        }
    }
}