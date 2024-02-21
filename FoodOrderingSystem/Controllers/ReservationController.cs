using FoodOrderingSystem.Core.DTOs;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FoodOrderingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [AllowAnonymous]
        [HttpPost("book-table")]
        public async Task<IActionResult> BookTable([FromBody] ReservationRequestDto request)
        {
            try
            {
                await _reservationService.BookTable(request);
                return Ok("Table booked successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles ="admin")]
        [HttpPost("confirm-reservation")]
        public async Task<IActionResult> ConfirmReservation(int reservationId)
        {
            await _reservationService.ConfirmReservation(reservationId);
            return Ok();
        }


        [HttpPost("reject-reservation")]
        public async Task<IActionResult> RejectReservation(int reservationId)
        {
            await _reservationService.RejectReservation(reservationId);
            return Ok();
        }


        [Authorize]
        [HttpGet("get-reservations")]
        public async Task<IActionResult> GetReservationHistory()
        {
            var history = await _reservationService.GetReservationHistory();
            return Ok(history);
        }
    }
}

