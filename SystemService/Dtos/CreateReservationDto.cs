using System;

namespace SystemService.Dtos
{
    public class CreateReservationDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int PricePerGuest { get; set; }
        public int PricePerAccomodation { get; set; }
        public int NumberOfPeople { get; set; }
        public string AccmodationId { get; set; }
    }
}
