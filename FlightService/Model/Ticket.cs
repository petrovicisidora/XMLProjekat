﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model
{
    public class Ticket : Entity
    {
        public Airport Airport { get; set; }
        public string PassengerID { get; set; }
        public Boolean IsReturning { get; set; }
        public Flight OneWayFlight { get; set; }
        public Flight ReturningFlight { get; set; }
    }
}
