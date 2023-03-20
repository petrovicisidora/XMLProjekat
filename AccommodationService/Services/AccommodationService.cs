using AccommodationService.Configuration;
using AccommodationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public class AccommodationService : BaseService<Accomodation>
    {
        private readonly ProjectConfiguration _configuration;

        public AccommodationService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }
    }
}
