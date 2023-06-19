using FlightService.Configuration;
using FlightService.Model;
using FlightService.Model.dto;
using FlightService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : BaseController<Ticket>
    {
        private readonly ITicketService _ticketService;
        private readonly IFlightService _flightService;
        public TicketController(ProjectConfiguration configuration, IUserService userService, ITicketService ticketService, IFlightService flight) : base(configuration, userService)
        {
            _ticketService = ticketService;
            _flightService = flight;
        }


        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ticketService.GetAll());
        }
        [Route("add")]
        [HttpPost]
        public IActionResult AddTicket(TicketDTO dto)
        {
            Flight f1=_flightService.Get(dto.FlightID);
            Ticket t1 = new Ticket();
            t1.Flight = f1;
            t1.PassengerID = dto.PassengerID;
            return Ok(_ticketService.Add(t1, dto.num));
        }

        [Route("ticket/{id}")]
        [HttpGet]
        public IActionResult Get(string id)
        {
            return Ok(_ticketService.Get(id));
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return Ok(_ticketService.Delete(id));
        }

        [Route("allByUser")]
        [HttpGet]
        public IActionResult GetbyUser([FromQuery] string user)
        {
            return Ok(_ticketService.GetbyUser(user));
        }
    }
}
