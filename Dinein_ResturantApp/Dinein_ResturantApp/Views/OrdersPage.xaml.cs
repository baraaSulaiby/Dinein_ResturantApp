using Dinein_ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dinein_ResturantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();
        }


        private async void ItemListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                // Get the selected item
                var selectedItem = (ReservationModel)e.Item;

                // Navigate to the detail page, passing the selected item as a parameter
                await Navigation.PushAsync(new DetailPage(selectedItem));
            }
        }
    }
}