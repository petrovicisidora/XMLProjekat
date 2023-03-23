using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Core;
using UserService.Model;

namespace UserService.Repository
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

        public User Get(long Id)
        {
            return UserContext.Users.Where(x => x.Id == Id && !x.Deleted).SingleOrDefault();
        }

    }
}
