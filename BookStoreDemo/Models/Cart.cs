using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreDemo.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public DateTime CartCreated { get; set; }

        public virtual Book BookToBuy { get; set; }

    }
}