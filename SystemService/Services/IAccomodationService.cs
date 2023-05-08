using System.Threading.Tasks;

namespace SystemService.Services
{
    public interface IAccomodationService
    {
        Task<AccomodationResponse> GetAccomodations();
    }
}
