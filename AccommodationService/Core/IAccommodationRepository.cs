using AccommodationService.Model;
using System.Collections.Generic;

namespace AccommodationService.Core
{
    public interface IAccommodationRepository : IBaseRepository<Accomodation>
    {
        IEnumerable<Accomodation> SearchByLocationAndCapacity(string location, int minCapacity, int maxCapacity);

        Accomodation Get(string id);
   
    }
}
