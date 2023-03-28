using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Core
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        Flight Get(long id);
    }
}
