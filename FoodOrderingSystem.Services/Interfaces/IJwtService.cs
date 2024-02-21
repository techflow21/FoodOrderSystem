using FoodOrderingSystem.Core.Entities;
using System.Security.Claims;

namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
