using AccommodationService.Core;
using AccommodationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Repositroy
{
    public class AccommodationRepository : BaseRepository<Accomodation>, IAccommodationRepository
    {
        public AccommodationRepository(AccommodationContext context) : base(context)
        {

        }
    }
}
