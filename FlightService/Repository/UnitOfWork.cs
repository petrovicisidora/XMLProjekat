using FlightService.Core;
using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightContext _context;

        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(FlightContext context)
        {
            _context = context;
            Flights = new FlightRepository(_context);
            Airports = new AirportRepository(_context);
            Tickets = new TicketRepository(_context);
        }

        public IFlightRepository Flights { get; private set; }
        public IAirportRepository Airports { get; private set; }
        public ITicketRepository Tickets { get; private set; }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if(_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            string type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            Type repositoryType = typeof(BaseRepository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }

        public FlightContext Context
        {
            get { return _context; }
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
