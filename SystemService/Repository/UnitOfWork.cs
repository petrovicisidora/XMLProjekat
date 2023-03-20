using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Core;
using SystemService.Model;

namespace SystemService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SystemContext _context;

        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(SystemContext context)
        {
            _context = context;
            Cities = new CityRepository(_context);
            Reservations = new ReservationRepository(_context);
           
        }

        public ICityRepository Cities { get; private set; }
        public IReservationRepository Reservations { get; private set; }
        

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
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

        public SystemContext Context
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
