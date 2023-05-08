using MongoDB.Bson.Serialization.Attributes;
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
        public int PricePerGuest { get; set; }
        public int PricePerAccomodation { get; set; }
        public string GuestId { get; set; }
        public string AccomodationId { get; set; }
        public int NumberOfPeople { get; set; }
        [BsonIgnore]
        public Accomodation Accomodation { get; set; }
    }
}
