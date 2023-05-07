using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemService.Services
{
    public class AccomodationService : IAccomodationService
    {
        public async  Task<AccomodationResponse> GetAccomodationById(string id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:8081");
            var client = new AccomodationGrpc.AccomodationGrpcClient(channel);
            var reply = await client.GetAccomodationInfoAsync(new AccomodationRequest() { Id = id });
            return reply;
        }
    }
}
