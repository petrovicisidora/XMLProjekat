using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemService.Model
{
    public class Reservations : Entity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Price { get; set; }
        public int NumberOfPeople { get; set; }
        public long GuestID { get; set; }
    }
}
