using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Model
{
    public class Accomodation : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Location Location { get; set; }
        public bool WifiIncluded { get; set; }
        public bool AcInclude { get; set; }
        public bool FreeParking { get; set; }
        public int MinCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public List<byte []> ImagePath { get; set; }

        public string Availability { get; set; }

    }
}
