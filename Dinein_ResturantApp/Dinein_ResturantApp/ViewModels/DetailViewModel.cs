using Dinein_ResturantApp.Models;
using Dinein_ResturantApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dinein_ResturantApp.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private readonly DataBase _database;

        public DetailViewModel()
        {
            _database = new DataBase();
        }

        private ReservationModel _reservation;
        public ReservationModel Reservation
        {
            get => _reservation;
            set => SetProperty(ref _reservation, value);
        }

        private List<OrderItem> _userOrders;
        public List<OrderItem> UserOrders
        {
            get => _userOrders;
            set => SetProperty(ref _userOrders, value);
        }

        public async Task LoadReservation(string reservationId)
        {
            IsBusy = true;

            try
            {

                // Retrieve the user's orders and assign the result to the UserOrders property
                UserOrders = await _database.GetUserOrders(Reservation.UserId);

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
