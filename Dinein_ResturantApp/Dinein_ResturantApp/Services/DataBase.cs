﻿using Dinein_ResturantApp.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinein_ResturantApp.Services
{
    public class DataBase
    {
        private readonly string FirebaseClientUrl = "https://dine-in-54308-default-rtdb.firebaseio.com/";
        private readonly string FirebaseSecretKey = "1AO003FSpm2dGZn4321C88RKPu2T6DPnKLfBr1Dg";

        private FirebaseClient _firebaseClient;
        public DataBase()
        {
            _firebaseClient = new FirebaseClient(FirebaseClientUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(FirebaseSecretKey)
            });

        }

        public async Task<List<ReservationModel>> GetAllReservations()
        {
            var reservationList = new List<ReservationModel>();
            var reservationModels = await _firebaseClient.Child(nameof(ReservationModel)).OnceAsync<ReservationModel>();

            foreach (var reservationModel in reservationModels)
            {
                var reservation = reservationModel.Object;

                if (reservation != null && !string.IsNullOrEmpty(reservation.UserId))
                {
                    var userQueryResult = await _firebaseClient.Child("Users")
                    .OrderBy("Id")
                    .EqualTo(reservation.UserId)
                    .OnceAsync<Users>();

                    if (userQueryResult.Any())
                    {
                        var user = userQueryResult.First().Object;
                        reservation.UserName = user.UserName;
                        reservation.UserEmail = user.Email;
                        Console.WriteLine("hiiiiiii" + user.UserName);

                    }
                }

                reservationList.Add(reservation);
            }

            return reservationList;
        }

        public async Task<List<OrderItem>> GetUserOrders(string userId)
        {
            var orderItems = new List<OrderItem>();

            // Query the orders node for orders with the specified userId
            var ordersQueryResult = await _firebaseClient.Child("orders")
                .OrderBy("userId")
                .EqualTo(userId)
                .OnceAsync<Dictionary<string, List<OrderItem>>>();

            // Get the list of order items from the orders data
            if (ordersQueryResult != null && ordersQueryResult.Count > 0 && ordersQueryResult.First().Object.TryGetValue("items", out List<OrderItem> items))
            {
                orderItems = items;
                Console.WriteLine("1111111111111111111111" + ordersQueryResult);

            }
            return orderItems;

        }



    }
}
