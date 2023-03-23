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
        protected BaseService<TEntity> _baseService;
        protected IUserService _userService;

        public BaseController(ProjectConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
            _baseService = new BaseService<TEntity>(configuration);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            TEntity entity = _baseService.Get(id);
            if (entity == null)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpPost]
        public virtual IActionResult Add(TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            TEntity response = _baseService.Add(entity);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            bool response = _baseService.Update(id, entity);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            bool response = _baseService.Delete(id);

            return Ok(response);
        }

        protected User GetCurrentUser()
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;

            return _userService.GetUserWithEmail(email);
        }


    }
}
