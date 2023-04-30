using AccommodationService.Configuration;
using AccommodationService.Model;
using AccommodationService.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly ProjectConfiguration _configuration;

        public AccommodationService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }

        public Accomodation Edit(string cITYid,string name, string price, string capapcity, string ava)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                Accomodation acc = new Accomodation();
                acc.Capacity = capapcity;
                acc.Availability = ava;
                acc.Name = name;
                acc.Price = price;
                acc.CityID = cITYid;
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
