using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;

namespace UserService.Services
{
    public class UserService : BaseService<User>
    {
        private readonly ProjectConfiguration _configuration;

        public UserService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }
    }
}
