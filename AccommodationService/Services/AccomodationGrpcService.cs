using AccommodationService.Configuration;
using AccommodationService.Core;
using AccommodationService.Repositroy;
using Grpc.Core;
using System;
using System.Collections.Generic;
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
            var accomodation = unitOfWork.Accommodations.Get(request.Id);
            return Task.FromResult(new AccomodationResponse()
            {
                Name = accomodation.Name,
                City = accomodation.Location.City,
                Street = accomodation.Location.Street,
                MaxPrice = accomodation.MaxCapacity,
                MinPrice = accomodation.MinCapacity,
                State = string.Empty
            });
        }
    }
}
