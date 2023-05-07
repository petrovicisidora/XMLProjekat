using AccommodationService.Configuration;
using AccommodationService.Dtos;
using AccommodationService.Model;
using AccommodationService.Repositroy;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly IWebHostEnvironment env;

        public AccommodationService(ProjectConfiguration projectConfiguration, IWebHostEnvironment env)
        {
            _configuration = projectConfiguration;
            this.env = env;
        }

        public Accomodation Edit(string cITYid,string name, int price, string capapcity, string ava)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                Accomodation acc = new Accomodation();
                //acc.Capacity = capapcity;
                acc.Availability = ava;
                acc.Name = name;
                acc.Price = price;
                //acc.CityID = cITYid;
                unitOfWork.Accommodations.Add(acc);
                return acc;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
           
        }
    }
}
