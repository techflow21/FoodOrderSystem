using Microsoft.AspNetCore.Http;

namespace FoodOrderingSystem.Services.ImageService
{
    public interface IAwsStorageService
    {
        Task<string> SaveImageToAWSStorage(IFormFile image, string fileName);
    }
}
