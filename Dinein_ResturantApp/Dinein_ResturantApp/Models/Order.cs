using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Dinein_ResturantApp.Models
{
    public class Order
    {
        public string Id { get; set; }
        public List<OrderItem> MenuItems { get; set; }
    }
 
}
