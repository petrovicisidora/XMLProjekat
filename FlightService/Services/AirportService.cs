using FlightService.Configuration;
using FlightService.Model;
using FlightService.Model.dto;
using FlightService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Services
{
    public class AirportService : BaseService<Airport>, IAirportService
    {
        private readonly ProjectConfiguration _configuration;

        public AirportService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }

        public IEnumerable<Airport> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());

                return unitOfWork.Airports.GetAll();
            }
            catch (Exception e)
            {
                return new List<Airport>();
            }
        }

        public override Airport Get(long Id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());

                return unitOfWork.Airports.Get(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        

        public Airport Delete(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());
                Airport airport = unitOfWork.Airports.Get(id);


                airport.Deleted = true;

                unitOfWork.Airports.Update(airport);
                unitOfWork.Complete();

                return airport;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Airport Edit(AirportDTO airportDTO)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());
                Airport airport = unitOfWork.Airports.Get(airportDTO.Id);

                airportDTO.CityID = airport.CityID;
                airportDTO.Name = airport.Name;
               
                unitOfWork.Airports.Update(airport);
                unitOfWork.Complete();

                return airport;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
