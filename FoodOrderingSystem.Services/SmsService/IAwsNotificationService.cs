
namespace FoodOrderingSystem.Services.SmsService
{
    public interface IAwsNotificationService
    {
        Task<bool> SendSmsAsync(string phoneNumber, string textMessage);
    }
}
