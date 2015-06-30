using System;
using System.Collections.Generic;

namespace BookStoreDemo.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string City{ get; set; }
        public string Address{ get; set; }
        public string Phone{ get; set; }
        public DateTime OrderDate{ get; set; }
        public decimal Total{ get; set; }
        
        public virtual ICollection<OrderDetails> OrderDetails{ get; set; }
    }
}