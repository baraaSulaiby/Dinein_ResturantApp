﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dinein_ResturantApp.Models
{
    public class ReservationModel
    {
        public string UserId { get; set; }
        public string ReservationId { get; set; }
        public string TimePicker { get; set; }
        public string NumberOfPeople { get; set; }
        public string Note { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }

    }
}
