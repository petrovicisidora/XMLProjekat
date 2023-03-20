using FlightService.Configuration;
using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public class AirportService : BaseService<Airport>
    {
        private readonly ProjectConfiguration _configuration;

        public AirportService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }
    }
}
