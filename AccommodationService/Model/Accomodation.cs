using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Model
{
    public class Accomodation : Entity
    {
        public long CityID { get; set; }
        public String Name { get; set; }
        public long Price { get; set; }
        public long Capacity { get; set; }
        public Boolean Availability { get; set; }

    }
}
