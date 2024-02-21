
using FoodOrderingSystem.Core.DTOs;

namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IUserService
    {
        //Task<RegisterDto> AddModeratorUser(RegisterDto model);
        Task<RegisterDto> AddModeratorUser(RegisterDto model, string imageString);
        Task<RegisterDto> AddAdminUser(RegisterDto model, string imageString);
        //Task<RegisterDto> AddAdminUser(RegisterDto model);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<RegisterDto> UpdateUser(string id, RegisterDto model, string imageString);
        //Task<RegisterDto> UpdateUser(string id, RegisterDto model);
        Task<bool> DeleteUser(string id);
        Task<bool> DeactivateUser(string id);
        Task<IEnumerable<UserDto>> SearchUsers(string searchQuery);
        Task AddUserToRole(string username, string roleName);
        Task<long> GetTotalRegisteredUsers();
    }
}
