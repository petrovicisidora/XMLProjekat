using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemService.Configuration;
using SystemService.Core;
using SystemService.Model;

namespace SystemService.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly IMongoCollection<City> _cityCollection;

        public CityRepository(ProjectConfiguration projectConfiguration)
        {
            var mongoClient = new MongoClient(
            projectConfiguration.DatabaseConfiguration.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectConfiguration.DatabaseConfiguration.DatabaseName);

            _cityCollection = mongoDatabase.GetCollection<City>("city");
        }

        public void Add(City entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(City entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> Find(Expression<Func<City, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public City Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(City entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<City> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public City SingleOrDefault(Expression<Func<City, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(City entity)
        {
            throw new NotImplementedException();
        }
    }
}
