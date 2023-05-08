using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemService.Services
{
    public class AccomodationService : IAccomodationService
    {
        public async  Task<AccomodationResponse> GetAccomodations()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:8081");
            var client = new AccomodationGrpc.AccomodationGrpcClient(channel);
            var reply = await client.GetAccomodationInfoAsync(new AccomodationRequest());
            return reply;
        }
    }
}
