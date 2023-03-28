using FlightService.Configuration;
using FlightService.Model;
using FlightService.Model.dto;
using FlightService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public class TicketService : BaseService<Ticket>, ITicketService
    {
        private readonly ProjectConfiguration _configuration;

        public TicketService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }

        public IEnumerable<Ticket> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());

                return unitOfWork.Tickets.GetAll();
            }
            catch (Exception e)
            {
                return new List<Ticket>();
            }
        }

        public override Ticket Get(long Id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());

                return unitOfWork.Tickets.Get(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public Ticket Delete(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());
                Ticket ticket = unitOfWork.Tickets.Get(id);


                ticket.Deleted = true;

                unitOfWork.Tickets.Update(ticket);
                unitOfWork.Complete();

                return ticket;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Ticket Edit(TicketDTO ticketDTO)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());
                Ticket ticket = unitOfWork.Tickets.Get(ticketDTO.Id);

                ticketDTO.Airport = ticket.Airport;
                ticketDTO.PassengerID = ticket.PassengerID;
                ticketDTO.IsReturning = ticket.IsReturning;
                ticketDTO.OneWayFlight = ticket.OneWayFlight;
                ticketDTO.ReturningFlight = ticket.ReturningFlight;


                unitOfWork.Tickets.Update(ticket);
                unitOfWork.Complete();

                return ticket;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
