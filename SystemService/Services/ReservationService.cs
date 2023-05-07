﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Reservations> Find(SearchReservationsDto dto)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            

            if (string.IsNullOrEmpty(dto.Location))
            {

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

            var reservations = unitOfWork.Reservations.Find(r => r.NumberOfPeople == dto.GuestNumber && r.Start >= dto.Start && r.End <= dto.End);

            return Enumerable.Empty<Reservations>();
        }
    }
}
