using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Core;
using UserService.Model;

namespace UserService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly UserContext _context;
        private ProjectConfiguration projectConfiguration;

        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(ProjectConfiguration projectConfiguration)
        {
            this.projectConfiguration = projectConfiguration;
            Users = new UserRepository(projectConfiguration);

        }

        public IUserRepository Users { get; private set; }


        public object User { get; private set; }


       

        public void Dispose()
        {
           
        }
    }
}
