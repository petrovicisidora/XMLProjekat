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
    public class FlightService : BaseService<Flight>, IFlightService
    {
        private readonly ProjectConfiguration _configuration;

        public FlightService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;
        }

        public IEnumerable<Flight> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());

                return unitOfWork.Flights.GetAll();
            }
            catch (Exception e)
            {
                return new List<Flight>();
            }
        }

        public override Flight Get(long Id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());

                return unitOfWork.Flights.Get(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public Flight Delete(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());
                Flight flight = unitOfWork.Flights.Get(id);


                flight.Deleted = true;

                unitOfWork.Flights.Update(flight);
                unitOfWork.Complete();

                return flight;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Flight Edit(FlightDTO flightDTO)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new FlightContext());
                Flight flight = unitOfWork.Flights.Get(flightDTO.Id);

                flightDTO.AirportDestination = flight.AirportDestination;
                flightDTO.AirportDeparture = flight.AirportDeparture;
                flightDTO.DepartureTime = flight.DepartureTime;
                flightDTO.ArrivalTime = flight.ArrivalTime;
                flightDTO.Duration = flight.Duration;
                flightDTO.TicketPrice = flight.TicketPrice;
                flightDTO.Capacity = flight.Capacity;


                unitOfWork.Flights.Update(flight);
                unitOfWork.Complete();

                return flight;
            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
}
