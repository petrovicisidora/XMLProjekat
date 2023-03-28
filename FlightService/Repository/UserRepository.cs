using FlightService.Core;
using FlightService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {

        }

        public User GetUserWithEmail(string email)
        {
            return UserContext.Users.Where(x => x.Email == email && !x.Deleted).SingleOrDefault();
        }
    }
}
