using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Configuration;
using SystemService.Model;

namespace SystemService.Services
{
    public class ReservationService : BaseService<Reservations>
    {
        private readonly ProjectConfiguration _configuration;

        public ReservationService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }
    }
}
