using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreDemo.Models
{
    public class Book
    {
        public Book() {}
        public virtual int BookId { get; set; }
        public virtual string BookName { get; set; }
        public virtual int BookNumberOfPages { get; set; }
        public virtual Author  BookAuthor { get; set; }      

    }
}