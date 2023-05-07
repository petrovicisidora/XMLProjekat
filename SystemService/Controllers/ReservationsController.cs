﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Configuration;
using SystemService.Dtos;
using SystemService.Exceptions;
using SystemService.Model;
using SystemService.Services;

namespace SystemService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : BaseController<Reservations>
    {
        private readonly IReservationService reservationService;

        public ReservationsController(
            ProjectConfiguration configuration, 
            IReservationService reservationService)
            : base(configuration)
        {
            this.reservationService = reservationService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Search([FromBody] SearchReservationsDto dto)
        { 
            return Ok();
        }

        [Route("remove/{id}")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                reservationService.DeleteReservation(id);
            }
            catch (ReservationNotFoundException ex)
            {
                return NotFound("Reservation not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [Route("cancel/{id}")]
        [HttpPut]
        public IActionResult Cancel(string id)
        {
            try
            {
                reservationService.CancelReservation(id);
            }
            catch (ReservationNotFoundException ex)
            {
                return NotFound("Reservation not found.");
            }
            catch (ReservationNotBooked ex)
            {
                return BadRequest("Reservation not booked.");
            }
            catch (ReservationCancellationException ex)
            {
                return BadRequest("You cannot cancel reservation on start date.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }

    
}
