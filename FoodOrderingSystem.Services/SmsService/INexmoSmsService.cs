
namespace FoodOrderingSystem.Services.SmsService
{
    public interface INexmoSmsService
    {
        void SendSms(string phoneNumber, string textMessage);
    }
}
