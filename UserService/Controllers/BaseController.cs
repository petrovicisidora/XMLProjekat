using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected ProjectConfiguration _configuration;
        //protected IAccommodationService _accommodationService;
      
        protected IUserService _userService;

        public BaseController(ProjectConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
          

       
        }

     

    }
}
