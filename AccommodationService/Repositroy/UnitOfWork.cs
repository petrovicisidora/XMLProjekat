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
        private readonly AccommodationContext _context;

        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(AccommodationContext context)
        {
            _context = context;
            Accommodations = new AccommodationRepository(_context);
        }

        public IAccommodationRepository Accommodations { get; private set;  }

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

        public AccommodationContext Context
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
