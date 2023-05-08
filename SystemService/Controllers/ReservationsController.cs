using Microsoft.AspNetCore.Authorization;
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
        private readonly IAccomodationService accomodationService;

        public ReservationsController(
            ProjectConfiguration configuration,
            IReservationService reservationService,
            IAccomodationService accomodationService)
            : base(configuration)
        {
            this.reservationService = reservationService;
            this.accomodationService = accomodationService;
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchReservationsDto dto)
        { 
           return Ok(await reservationService.Find(dto));
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateReservationDto dto)
        {
            Reservations reservation = null;
            try
            {
                reservation = reservationService.CreateReservation(dto);
                if (reservation == null)
                {
                    return BadRequest("Bad data sent.");
                }
            }
            catch (ReservationAlreadyExistisException ex)
            {
                return BadRequest("Reservation already created.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return Ok(reservation);
        }

        [Route("edit")]
        [HttpPut]
        public IActionResult Edit([FromBody] EditReservationDto dto)
        {
            try
            {
                reservationService.EditReservation(dto);
            }
            catch (ReservationNotFoundException ex)
            {
                return NotFound("Reservation not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return NoContent();
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