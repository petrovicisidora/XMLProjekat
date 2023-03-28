using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Core
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithEmail(string email);
    }
}
