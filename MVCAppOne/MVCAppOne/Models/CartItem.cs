using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppOne.Models
{
    public class CartItem
    {
        public Album Album { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}