using AccommodationService.Configuration;
using AccommodationService.Repositroy;
using AccomodationService;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public class AccomodationGrpcService : AccomodationGrpc.AccomodationGrpcBase
    {
        private readonly ProjectConfiguration projectConfiguration;

        public AccomodationGrpcService(ProjectConfiguration projectConfiguration)
        {
            this.projectConfiguration = projectConfiguration;
        }

        public override Task<AccomodationResponse> GetAccomodationInfo(AccomodationRequest request, ServerCallContext context)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(projectConfiguration);
            var accomodations = unitOfWork.Accommodations.Find((acc) => true);
            var accomodationResponse = new AccomodationResponse();
            accomodationResponse.Accomodations.AddRange(accomodations.Select(x => new Accomodation()
            {
                Name = x.Name,
                City = x.Location.City,
                Street = x.Location.Street,
                MaxPrice = x.MaxCapacity,
                MinPrice = x.MinCapacity,
                State = x.Location.State
            }));
            return Task.FromResult(accomodationResponse);
        }
    }
}
