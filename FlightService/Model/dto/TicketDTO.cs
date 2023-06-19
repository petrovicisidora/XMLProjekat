using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model.dto
{
    public class TicketDTO : Entity
    {
        public string FlightID { get; set; }
        public string PassengerID { get; set; }

        public int num { get; set; }
       
    }
}
