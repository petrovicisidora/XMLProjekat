using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model
{
    public class Ticket : Entity
    {
        public Flight Flight { get; set; }
        public string PassengerID { get; set; }
      
    }
}
