using MimeKit;

namespace FoodOrderingSystem.Services.EmailService
{
    public interface IMailKitEmailService
    {
        Task SendEmailAsync(MimeMessage message);
    }
}
