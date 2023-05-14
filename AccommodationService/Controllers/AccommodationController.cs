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
        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            IEnumerable<Accomodation> accs =  _accService.GetAll();
            if (accs == null)
            {
                return BadRequest("Accomodation failed to load.");
            }

            return Ok(accs); ;
        }

        [Route("search")]
        [HttpGet]
        public IActionResult SearchAccommodation(string location, int guestsNo, DateTime start, DateTime end)
        {
            try
            {
                var accommodations = _accService.PretraziSmestaj(location, guestsNo, start, end);
                return Ok(accommodations);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an appropriate response
                return StatusCode(500, "An error occurred while searching for accommodations.");
            }
        }

    }
}