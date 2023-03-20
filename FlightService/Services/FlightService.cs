using FlightService.Configuration;
using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public class FlightService : BaseService<Flight>
    {
        private readonly ProjectConfiguration _configuration;

        public FlightService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }
    }
}
