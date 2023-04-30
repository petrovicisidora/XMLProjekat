using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Configuration;
using SystemService.Services;

namespace SystemService.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected ProjectConfiguration _configuration;
        //protected IAccommodationService _accommodationService;


        public BaseController(ProjectConfiguration configuration)
        {
            _configuration = configuration;

        }
    }
}