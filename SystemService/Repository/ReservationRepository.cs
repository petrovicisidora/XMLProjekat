using MongoDB.Bson;
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
    public class ReservationRepository :  IReservationRepository
    {
        private readonly IMongoCollection<Reservations> _reservationCollection;

        public  ReservationRepository(ProjectConfiguration projectConfiguration)
        {
            var mongoClient = new MongoClient(
            projectConfiguration.DatabaseConfiguration.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectConfiguration.DatabaseConfiguration.DatabaseName);

            _reservationCollection = mongoDatabase.GetCollection<Reservations>("reservation");
        }

        public void Add(Reservations entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(Reservations entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservations> Find(Expression<Func<Reservations, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reservations Get(long id)
        {
            throw new NotImplementedException();
        }

        public Reservations Get(string id)
        {
            var filter = Builders<Reservations>.Filter.Eq("_id", new ObjectId(id));
            return _reservationCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<Reservations> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservations> GetByAccomodationId(string accomodationId)
        {
            var filter = Builders<Reservations>.Filter.Eq("accomodationId", accomodationId);
            return _reservationCollection.Find(filter).ToEnumerable();
        }

        public void Remove(Reservations entity)
        {
            var filter = Builders<Reservations>.Filter.Eq("_id", new ObjectId(entity.Id));
            _reservationCollection.DeleteOne(filter);
        }

        public void RemoveRange(IEnumerable<Reservations> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservations> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public Reservations SingleOrDefault(Expression<Func<Reservations, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservations entity)
        {
            var filter = Builders<Reservations>.Filter.Eq("_id", new ObjectId(entity.Id));
            _reservationCollection.ReplaceOne(filter, entity);
        }
    }
}
