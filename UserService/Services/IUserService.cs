using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Model.dto;

namespace UserService.Services
{
    public interface IUserService
    {
        User GetUserWithEmail(string email);
        User Registration(string email, string password, string name, string surname, string city, string type);
        IEnumerable<User> GetAll();
        User Get(long Id);
        User Delete(long id);
        void Update(User user);
    }
}
