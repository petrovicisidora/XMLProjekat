using AccommodationService.Model;
using Microsoft.AspNetCore.Http;

namespace AccommodationService.Dtos
{
    public class AccomodationDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Location Location { get; set; }
        public bool WifiIncluded { get; set; }
        public bool AcInclude { get; set; }
        public bool FreeParking { get; set; }
        public int MinCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public IFormFile Image { get; set; }

    }
}
