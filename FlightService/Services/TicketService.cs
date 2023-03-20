using FlightService.Configuration;
using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public class TicketService : BaseService<Ticket>
    {
        private readonly ProjectConfiguration _configuration;

        public TicketService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }
    }
}
