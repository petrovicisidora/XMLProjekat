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
        Ticket Get(string Id);
        Boolean Delete(string id);
        Ticket Add(Ticket t, int num);
        bool FlightDeleted(string id);

        IEnumerable<Flight> GetbyUser(string user);
    }
}
