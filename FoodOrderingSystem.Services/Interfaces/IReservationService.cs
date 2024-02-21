
using FoodOrderingSystem.Core.DTOs;

namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IReservationService
    {
        Task BookTable(ReservationRequestDto request);
        Task<IEnumerable<ReservationRequestDto>> GetReservationHistory();
        Task ConfirmReservation(int reservationId);
        Task RejectReservation(int reservationId);
    }
}
