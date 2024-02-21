using Microsoft.AspNetCore.Http;

namespace FoodOrderingSystem.Services.ImageService
{
    public interface ILocalStorageService
    {
        Task<string> SaveImageToLocalFileSystem(IFormFile image, string fileName);
    }
}
