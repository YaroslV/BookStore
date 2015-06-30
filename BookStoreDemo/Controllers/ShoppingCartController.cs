using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreDemo.Models;
using BookStoreDemo.ViewModel;

namespace BookStoreDemo.Controllers
{
    public class ShoppingCartController : Controller
    {
        BookStoreDemoDBContext storeDB = new BookStoreDemoDBContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this);
            var cartList = new CartViewModel() { CartItems = cart.GetCartItems() };
            return View(cartList);
        }
    }
}