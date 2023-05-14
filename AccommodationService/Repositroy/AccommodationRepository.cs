using AccommodationService.Configuration;
using AccommodationService.Core;
using AccommodationService.Model;
using MongoDB.Bson;
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

        private readonly IMongoCollection<Accomodation> _accomodation;

        public AccommodationRepository(ProjectConfiguration projectConfiguration)
        {
            /*var mongoClient = new MongoClient(
            projectConfiguration.DatabaseConfiguration.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectConfiguration.DatabaseConfiguration.DatabaseName);

            _accommodationCollection = mongoDatabase.GetCollection<Accomodation>("accommodationService");*/
        }

        public AccommodationRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = client.GetDatabase("accommodationService");
            _accomodation = mongoDatabase.GetCollection<Accomodation>("accommodation");
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

        public Accomodation Get(string id)
        {
                if (_accomodation == null)
                {
                    throw new InvalidOperationException("Accommodation collection is not initialized.");
                }

                var filter = Builders<Accomodation>.Filter.Eq(a => a.Id, id);
                var accommodation = _accomodation.Find(filter).FirstOrDefault();

                return accommodation;
            
        }

        public IEnumerable<Accomodation> GetAll()
        {
            return _accommodationCollection.Find(_ => true).ToList();
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

        public IEnumerable<Accomodation> SearchByLocationAndCapacity(string location, int minCapacity, int maxCapacity)
        {
            var filter = Builders<Accomodation>.Filter.Where(x => x.Location.City == location && x.MinCapacity <= minCapacity && x.MaxCapacity >= maxCapacity);
            return _accommodationCollection.Find(filter).ToList();
        }
    }
}
