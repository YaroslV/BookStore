using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreDemo.Models
{
    public partial class OrderManager
    {
        BookStoreDemoDBContext bookDB = new BookStoreDemoDBContext();

        private Order order = null;
        
        
        public const string CartSessionKey = "CartId";
        public static OrderManager GetCart(HttpContextBase context)
        {
            var cart = new OrderManager();           
            return cart;
        }
        
        // Helper method to simplify shopping cart calls
        public static OrderManager GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToOrder(Book book)
        {
            if(order != null)
            {
                order.BooksInOrder.Add(book);
            }
            else
            {
                order = new Order();
                order.BooksInOrder.Add(book);
            }

            bookDB.Orders.Add(order);
            bookDB.SaveChanges();
        }        
    }
}