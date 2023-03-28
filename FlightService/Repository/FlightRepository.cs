using FlightService.Core;
using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Repository
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(FlightContext context) : base(context)
        {

        }

        public Flight Get(long Id)
        {
            return FlightContext.Flights.Where(x => x.Id == Id && !x.Deleted).SingleOrDefault();
        }
    }
}
