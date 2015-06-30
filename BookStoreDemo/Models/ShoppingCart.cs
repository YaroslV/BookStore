using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreDemo.Models
{
    public class ShoppingCart
    {
        BookStoreDemoDBContext dbContext = new BookStoreDemoDBContext();
        string ShoppingCartId {get; set;}

        public const string CarSessionKey = "CartId";       
        
        public static string GetCardIdFromSession(HttpContextBase context)
        {
            if(context.Session[CarSessionKey] == null)
            {
                if (string.IsNullOrWhiteSpace(context.User.Identity.Name) != true)
                {
                    context.Session[CarSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CarSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CarSessionKey].ToString();
        }

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = GetCardIdFromSession(context);
            return shoppingCart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        
        public void AddToCart(Book book)
        {
            var cartItem = dbContext.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.BookId == book.BookId );
            if (cartItem == null)
            {
                cartItem = new Cart() { 
                    CartId = ShoppingCartId,
                    CartCreated = DateTime.Now,
                    BookId = book.BookId,
                    Count = 1
                };
                dbContext.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            dbContext.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = dbContext.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.BookId == id);
            int itemCount = 0;
            
            if(cartItem != null)
            {
                cartItem.Count--;
                if(cartItem.Count == 0)
                {
                    dbContext.Carts.Remove(cartItem);
                }
                else
                {
                    itemCount = cartItem.Count;
                }
                dbContext.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = dbContext.Carts.Where(c => c.CartId == ShoppingCartId); 
            foreach( var c in cartItems)
            {
                dbContext.Carts.Remove(c);
            }
            dbContext.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return dbContext.Carts.Where(c => c.CartId == ShoppingCartId).ToList();
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            foreach(var c in cartItems)
            {
                var orderDetails = new OrderDetails() { 
                    BookId = c.BookId,
                    OrderId = order.OrderId,
                    UnitPrice = c.BookToBuy.Price,
                    Quantity = c.Count
                };

                dbContext.OrderDetails.Add(orderDetails);
                orderTotal += (c.Count * c.BookToBuy.Price);
            }

            order.Total = orderTotal;
            order.OrderDate = DateTime.Now;
            dbContext.SaveChanges();
            EmptyCart();
            
            return order.OrderId;
        }
    }
}