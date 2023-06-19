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
    public class TicketService : ITicketService
    {
        private readonly ProjectConfiguration _configuration;

        public TicketService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;

        }

        public IEnumerable<Ticket> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                return unitOfWork.Tickets.GetAll();
            }
            catch (Exception e)
            {
                return new List<Ticket>();
            }
        }

        public Ticket Get(string Id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                return unitOfWork.Tickets.Get(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public bool Delete(string id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                unitOfWork.Tickets.Delete(id);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        

        public Ticket Add(Ticket t, int num)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
                for(int i = 0; i < num; i++) {
                    Ticket tt = new Ticket();
                    tt.Flight = t.Flight;
                    tt.PassengerID = t.PassengerID;
                    unitOfWork.Tickets.Add(tt);
                }
                
                Flight e = new Flight();
                e = t.Flight;
                e.Capacity = t.Flight.Capacity - num;
                unitOfWork.Flights.Update(e);
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool FlightDeleted(string id)
        {
            IEnumerable<Ticket> ticks = GetAll();
            List<Ticket> tt=ticks.ToList();
            foreach(Ticket t in tt)
            {
                if (t.Flight.Id == id)
                {
                    Delete(t.Id);
                }
            }

            return true;

        }

        public IEnumerable<Flight> GetbyUser(string user)
        {
            IEnumerable<Ticket> ticks = GetAll();
        
            List<Ticket> tt = ticks.ToList();
            List<Flight> ttr = new List<Flight>();
            foreach (Ticket t in tt)
            {
                if (t.PassengerID == user)
                {
                    ttr.Add(t.Flight);
                }
            }
            return ttr;
        }
    }
}
