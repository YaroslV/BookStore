using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreDemo.Models
{
    public class Author
    {
        public Author()
        {
            AuthorsBooks = new List<Book>();
        }
        public virtual int AuthorId { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual IList<Book> AuthorsBooks { get; set; }
    }
}
