using FoodOrderingSystem.Core.DTOs;

namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IContactService
    {
        Task SubmitContactForm(ContactRequestDto request);
    }
}
