using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Core;
using SystemService.Model;

namespace SystemService.Repository
{
    public class ReservationRepository : BaseRepository<Reservations>, IReservationRepository
    {
        public ReservationRepository(SystemContext context) : base(context)
        {

        }
    }
}
