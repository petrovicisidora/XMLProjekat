using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Core;
using UserService.Model;

namespace UserService.Repository
{
    public class UserRepository :  IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(ProjectConfiguration projectConfiguration)
        {
            var mongoClient = new MongoClient(
             projectConfiguration.DatabaseConfiguration.ConnectionString);

             var mongoDatabase = mongoClient.GetDatabase(
                 projectConfiguration.DatabaseConfiguration.DatabaseName);
            
        
            _userCollection = mongoDatabase.GetCollection<User>("user");
        }

        public void Add(User entity)
        {
            _userCollection.InsertOne(entity);
        }

        public void Detach(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserWithEmail(string email)
        {
            return null;
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public User SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
