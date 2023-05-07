using System.Collections.Generic;
using SystemService.Dtos;
using SystemService.Model;

namespace SystemService.Services
{
    public interface IReservationService
    {
        Reservations GetById(string reservationId)
        void DeleteReservation(string id);
        void CancelReservation(string reservationId);
        IEnumerable<Reservations> Find(SearchReservationsDto dto);
    }
}
