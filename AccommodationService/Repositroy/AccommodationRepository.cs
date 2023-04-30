using AccommodationService.Configuration;
using AccommodationService.Core;
using AccommodationService.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AccommodationService.Repositroy
{
    public class AccommodationRepository :  IAccommodationRepository
    {
        private readonly IMongoCollection<Accomodation> _accommodationCollection;

        public AccommodationRepository(ProjectConfiguration projectConfiguration)
        {
            var mongoClient = new MongoClient(
            projectConfiguration.DatabaseConfiguration.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectConfiguration.DatabaseConfiguration.DatabaseName);

            _accommodationCollection = mongoDatabase.GetCollection<Accomodation>("accommodation");
        }

        public void Add(Accomodation entity)
        {
            _accommodationCollection.InsertOne(entity);
        }

        public void Detach(Accomodation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accomodation> Find(Expression<Func<Accomodation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Accomodation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accomodation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Accomodation entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Accomodation> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accomodation> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public Accomodation SingleOrDefault(Expression<Func<Accomodation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Accomodation entity)
        {
            throw new NotImplementedException();
        }
    }
}
