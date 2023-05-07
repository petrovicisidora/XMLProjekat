using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Model;

namespace SystemService.Core
{
    public interface IReservationRepository : IBaseRepository<Reservations>
    {
        IEnumerable<Reservations> GetByAccomodationId(string accomodationId);
        Reservations Get(string id);
    }
}
