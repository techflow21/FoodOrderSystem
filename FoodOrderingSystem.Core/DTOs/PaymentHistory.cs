namespace FoodOrderingSystem.Core.DTOs
{
    public class PaymentHistory
    {
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
