﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model
{
    public class Airport : Entity
    {
        public long CityID { get; set; }
        public String Name { get; set; }
    }
}
