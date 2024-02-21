namespace FoodOrderingSystem.Core.DTOs
{
    public class ExternalAuthRequest
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
    }
}
