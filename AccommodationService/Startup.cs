using AccommodationService.Configuration;
using AccommodationService.Model;
using AccommodationService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Grpc.Core;
using System.Threading.Tasks;
using AccomodationService;
using AccommodationService.Repositroy;
using AccommodationService.Core;

namespace AccommodationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            var config = new ProjectConfiguration();
            Configuration.Bind("ProjectConfiguration", config);      //  <--- This

            services.AddSingleton(config);

            services.AddGrpc();

            services.AddScoped<IAccommodationService, Services.AccommodationService>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
           
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        private Server server;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseCors("MyPolicy");


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<AccomodationGrpcService>();
            });

            server = new Server
            {
                Services = { AccommodationGrpc.BindService(new AccomodationGrpcService()) },
                Ports = { new ServerPort("localhost", 4112, ServerCredentials.Insecure) }
            };
            server.Start();
        }
    }
}
