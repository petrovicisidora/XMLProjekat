using System.Collections.Generic;
using System.Threading.Tasks;
using SystemService.Dtos;
using SystemService.Model;

namespace SystemService.Services
{
    public interface IReservationService
    {
        Reservations GetById(string reservationId);
        Reservations CreateReservation(CreateReservationDto dto);
        Reservations EditReservation(EditReservationDto dto);
        void DeleteReservation(string id);
        void CancelReservation(string reservationId);
        Task<IEnumerable<Reservations>> Find(SearchReservationsDto dto);
    }
}
