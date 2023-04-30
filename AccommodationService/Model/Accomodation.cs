using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Model
{
    public class Accomodation : Entity
    {
        public string CityID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Capacity { get; set; }
        public string Availability { get; set; }

    }
}
