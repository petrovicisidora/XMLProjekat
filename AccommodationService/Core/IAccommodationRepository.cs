using AccommodationService.Model;

namespace AccommodationService.Core
{
    public interface IAccommodationRepository : IBaseRepository<Accomodation>
    {
        Accomodation Get(string id);
    }
}
