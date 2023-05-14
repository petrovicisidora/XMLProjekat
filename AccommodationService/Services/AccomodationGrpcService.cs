using AccommodationService.Configuration;
using AccommodationService.Core;
using AccommodationService.Model;
using AccommodationService.Repositroy;
using AccomodationService;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;
using Location = AccommodationService.Model.Location;

namespace AccommodationService.Services
{
    public class AccomodationGrpcService  : AccommodationGrpc.AccommodationGrpcBase
    {
       
            IAccommodationRepository accommodationRepository = new AccommodationRepository(); // replace with your implementation of IAccommodationRepository

        
            public AccomodationGrpcService(IAccommodationRepository repository)
            {
                accommodationRepository = repository;
            }

            public AccomodationGrpcService()
            {

            }

        
        public override Task<AccommodationResponse> GetAccommodationInfo(AccommodationRequest request, ServerCallContext context)
            {
                // Retrieve the accommodation from the database using the ID
                var accommodation = accommodationRepository.Get(request.Id);

                // If the accommodation is not found, return an error
                if (accommodation == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Accommodation with ID '{request.Id}' not found."));
                }

                // Map the Accommodation entity to AccommodationResponse proto
                AccommodationResponse response = new AccommodationResponse
                {
                    Name = accommodation.Name,
                    Price = accommodation.Price,
                    /*Location = new Location
                    {
                        Address = accommodation.Location.Address,
                        City = accommodation.Location.City,
                        Country = accommodation.Location.Country
                    },*/
                    WifiIncluded = accommodation.WifiIncluded,
                    //AcIncluded = accommodation.AcIncluded,
                    FreeParking = accommodation.FreeParking,
                    MinCapacity = accommodation.MinCapacity,
                    MaxCapacity = accommodation.MaxCapacity,
                    //ImagePath = { accommodation.ImagePath },
                    Availability = accommodation.Availability
                };
                return Task.FromResult(response);
            }                     
        }
    }
