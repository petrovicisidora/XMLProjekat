using AccommodationService.Configuration;
using AccommodationService.Dtos;
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

        public AccommodationController(ProjectConfiguration configuration, IAccommodationService airportService) : base(configuration, airportService)
        {
            _accService = airportService;

        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AccomodationDto dto)
        {

            Accomodation user = await _accService.Create(dto);
            if (user == null)
            {
                return BadRequest("Accomodation failed to create.");
            }

            return Ok(user); ;
        }

        [Route("edit")]
        [HttpPost]
        public IActionResult Edit(Accomodation ticketDTO)
        {

            Accomodation user = _accService.Edit(string.Empty, ticketDTO.Availability, ticketDTO.Price, ticketDTO.Name, string.Empty);
            if (user == null)
            {
                return BadRequest("Registration is not successful.");
            }

            return Ok(user); ;
        }
    }
}