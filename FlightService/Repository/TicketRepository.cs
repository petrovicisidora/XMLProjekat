using FlightService.Core;
using FlightService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Repository
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(FlightContext context) : base(context)
        {

        }

        public Ticket Get(long Id)
        {
            return FlightContext.Tickets.Where(x => x.Id == Id && !x.Deleted).SingleOrDefault();
        }
    }
}
