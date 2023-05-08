using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Configuration;
using SystemService.Dtos;
using SystemService.Exceptions;
using SystemService.Model;
using SystemService.Repository;

namespace SystemService.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly IAccomodationService accomodationService;

        public ReservationService(ProjectConfiguration projectConfiguration, IAccomodationService accomodationService)
        {
            _configuration = projectConfiguration;
            this.accomodationService = accomodationService;
        }

        public Reservations CreateReservation(CreateReservationDto dto)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

            var reservations = unitOfWork.Reservations.GetByAccomodationId(dto.AccmodationId);
            if (reservations.Any(a => a.Start >= dto.Start && a.Start <= dto.End))
            {
                throw new ReservationAlreadyExistisException();
            }

            var reservation = new Reservations()
            {
                AccomodationId = dto.AccmodationId,
                NumberOfPeople = dto.NumberOfPeople,
                PricePerAccomodation = dto.PricePerAccomodation,
                Start = dto.Start,
                End = dto.End,
                PricePerGuest = dto.PricePerGuest
            };

            unitOfWork.Reservations.Add(reservation);
            return reservation;

        }

        public Reservations EditReservation(EditReservationDto dto)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

            var reservation = unitOfWork.Reservations.Get(dto.ReservationId);
            if (reservation == null)
            {
                throw new ReservationNotFoundException();
            }

            unitOfWork.Reservations.Update(reservation);
            return reservation;

        }

        public Reservations GetById(string reservationId)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            return unitOfWork.Reservations.Get(reservationId);
        }

        public void DeleteReservation(string id)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            var reservation = unitOfWork.Reservations.Get(id);
            if (reservation == null)
            {
                throw new ReservationNotFoundException();
            }

            unitOfWork.Reservations.Remove(reservation);
        }

        public void CancelReservation(string reservationId)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            var reservation = unitOfWork.Reservations.Get(reservationId);
            if (reservation == null)
            {
                throw new ReservationNotFoundException();
            }

            if (reservation.GuestId != null)
            {
                throw new ReservationNotBooked();
            }

            var today = DateTime.Now;
            if (reservation.Start > today.AddDays(-1))
            {
                throw new ReservationCancellationException();
            }

            reservation.GuestId = null;
            unitOfWork.Reservations.Update(reservation);
        }

        public async Task<IEnumerable<Reservations>> Find(SearchReservationsDto dto)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            var accomodationResponse = await accomodationService.GetAccomodations();
            var accomodations = accomodationResponse.Accomodations.ToList();

            var reservations = unitOfWork.Reservations.Find(r => r.NumberOfPeople == dto.GuestNumber && r.Start >= dto.Start && r.End <= dto.End);

            foreach (var reservation in reservations)
            {
                reservation.Accomodation = accomodations.FirstOrDefault(x => x.Id.Equals(reservation.AccomodationId));
            }

            if (string.IsNullOrEmpty(dto.Location))
            {
                reservations = reservations.Where(x => x.Accomodation.City.ToLower().Contains(dto.Location.ToLower()) ||
                    x.Accomodation.Street.ToLower().Contains(dto.Location.ToLower()) ||
                    x.Accomodation.State.ToLower().Contains(dto.Location.ToLower())
                );
            }

            if (dto.GuestNumber != 0)
            {

            }

            if (dto.Start != null)
            {

            }

            if (dto.End != null)
            {

            }

            return reservations;
        }
    }
}