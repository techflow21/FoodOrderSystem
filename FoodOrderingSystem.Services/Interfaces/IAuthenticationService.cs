
using FoodOrderingSystem.Core.DTOs;

namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDto> Authenticate(AuthenticationRequestDto model);
        Task<RegisterDto> Register(RegisterDto model);
        Task ConfirmEmailAsync(string userId, string token);
        Task<bool> ResetPassword(ResetPasswordDto model);
        Task<AuthenticationResponseDto> ForgotPassword(ForgotPasswordDto model);
        Task Logout();
    }
}
