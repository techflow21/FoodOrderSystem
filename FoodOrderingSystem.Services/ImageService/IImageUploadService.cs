using Microsoft.AspNetCore.Http;

namespace FoodOrderingSystem.Services.ImageService
{
    /*public interface IImageUploadService
    {
        Task<string> UploadImage(IFormFile formFile);
    }*/

    public interface IImageUploadService
    {
        Task<string> PhotoUpload(IFormFile file);
    }
}
