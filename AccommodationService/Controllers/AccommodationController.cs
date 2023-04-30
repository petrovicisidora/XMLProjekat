using AccommodationService.Configuration;
using AccommodationService.Model;
using AccommodationService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccommodationController : BaseController<Accomodation>
    {
        private readonly IAccommodationService _accService;

        public AccommodationController(ProjectConfiguration configuration,  IAccommodationService airportService) : base(configuration, airportService)
        {
            _accService = airportService;

        }

        [Route("add")]
        [HttpPost]
        public IActionResult Edit(Accomodation ticketDTO)
        {

            Accomodation user = _accService.Edit(ticketDTO.CityID, ticketDTO.Availability, ticketDTO.Capacity,ticketDTO.Name,ticketDTO.Price);
            if (user == null)
            {
                return BadRequest("Registration is not successful.");
            }

            return Ok(user); ;
        }
    }
}
