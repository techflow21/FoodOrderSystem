
using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Core.DTOs
{
    public class ReservationRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? Time { get; set; }

        [Required]
        public int Guests { get; set; }
        public string? Menu { get; set; }
    }
}
