using AccommodationService.Configuration;
using AccommodationService.Core;
using AccommodationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Repositroy
{
    public class UnitOfWork : IUnitOfWork
    {
        //vate readonly AccommodationContext _context;
        private ProjectConfiguration projectConfiguration;
        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(ProjectConfiguration projectConfiguration)
        {
            this.projectConfiguration = projectConfiguration;
            Accommodations = new AccommodationRepository(projectConfiguration);
        }

        public IAccommodationRepository Accommodations { get; private set;  }

      

        public void Dispose()
        {
           
        }
    }
}
