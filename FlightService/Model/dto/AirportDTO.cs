﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model.dto
{
    public class AirportDTO : Entity
    {
        public long CityID { get; set; }
        public string Name { get; set; }
    }
}
