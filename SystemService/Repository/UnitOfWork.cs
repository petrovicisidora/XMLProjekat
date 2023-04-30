using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Configuration;
using SystemService.Core;
using SystemService.Model;

namespace SystemService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //ivate readonly SystemContext _context;
        private ProjectConfiguration projectConfiguration;

        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(ProjectConfiguration projectConfiguration)
        {
            //_context = context;
            this.projectConfiguration = projectConfiguration;
            Cities = new CityRepository(projectConfiguration);
            Reservations = new ReservationRepository(projectConfiguration);
           
        }

        public ICityRepository Cities { get; private set; }
        public IReservationRepository Reservations { get; private set; }

      
        public void Dispose()
        {
          
        }
    }
}
