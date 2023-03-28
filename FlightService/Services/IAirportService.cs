using FlightService.Model;
using FlightService.Model.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAll();
        Airport Get(long Id);
        Airport Delete(long id);
        Airport Edit(AirportDTO airportDTO);
    }
}
