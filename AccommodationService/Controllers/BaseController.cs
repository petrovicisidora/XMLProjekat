using AccommodationService.Configuration;
using AccommodationService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected ProjectConfiguration _configuration;
        protected IAccommodationService _accService;


        public BaseController(ProjectConfiguration configuration, IAccommodationService acc)
        {
            _configuration = configuration;
            _accService = acc;
          
        }
    }
}
