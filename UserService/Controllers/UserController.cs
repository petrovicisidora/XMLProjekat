using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Model.dto;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController<User>
    {
        private readonly IUserService _userService;
        private readonly ProjectConfiguration _configuration;
        

        public UserController(ProjectConfiguration configuration, IUserService userService) : base(configuration, userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [Route("registration")]
        [HttpPost]
        public IActionResult Registration(RegistrationDTO registration)
        {
            User user = _userService.Registration(registration.Email, registration.Password, registration.Name, registration.Surname, registration.City, registration.Type);

            if (user == null)
            {
                return BadRequest("Registration is not successful.");
            }

            return Ok(user);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_userService.GetAll());
        }

        [Route("/{id}")]
        [HttpGet]
        public IActionResult Get(long id)
        {
            return Ok(_userService.Get(id));
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(long id)
        {
            return Ok(_userService.Delete(id));
        }

        [Route("{email}")]
        [HttpPut]
        public IActionResult Edit(User user,string email)
        {
            user.Email = email;
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if (email != user.Email)
            {
                return BadRequest("mars");
            }
            
            _userService.Update(user);
            return Ok(user);
        }
            
            
            
            
        
    }
}
