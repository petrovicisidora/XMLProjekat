using AccomodationService;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            
            CreateHostBuilder(args).Build().Run();
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new AccommodationGrpc.AccommodationGrpcClient(channel);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
