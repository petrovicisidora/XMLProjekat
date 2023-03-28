using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Core
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {

        Ticket Get(long id);
    }
}
