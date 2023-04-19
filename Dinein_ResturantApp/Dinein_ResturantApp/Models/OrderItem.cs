using System;
using System.Collections.Generic;
using System.Text;

namespace Dinein_ResturantApp.Models
{
    public class OrderItem
    {
        public string MenuItemName { get; set; }
        public decimal MenuItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserId { get; internal set; }
    }
}
