using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreDemo.Models
{
    public class Order
    {
        public Order()
        {
            BooksInOrder = new List<Book>();
        }
        public int OrderId { get; set; }
        public string OrderCountry  { get; set; }
        public string OrderCity { get; set; }
        public virtual ICollection<Book> BooksInOrder { get; set; }
    }
}