using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;

namespace UserService.Model
{
    public class UserContext : DbContext
    {
        private static ProjectConfiguration _configuration;

        public UserContext(DbContextOptions<UserContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public UserContext()
        {

        }

    }
}
