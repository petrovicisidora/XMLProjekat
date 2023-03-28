using FlightService.Model;
using FlightService.Model.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket Get(long Id);
        Ticket Delete(long id);
        Ticket Edit(TicketDTO ticketDTO);
    }
}
