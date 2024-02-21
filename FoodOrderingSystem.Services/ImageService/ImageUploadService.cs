using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace FoodOrderingSystem.Services.ImageService
{
    public class ImageUploadService : IImageUploadService
    {
        public async Task<string> PhotoUpload(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException("File is missing or empty");

            string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            Directory.CreateDirectory(imageFolderPath);

            var fullPath = Path.Combine(imageFolderPath, filename);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine("Images", filename);
        }
    }


    /*public class ImageUploadService : IImageUploadService
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService()
        {
            //_webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImage(IFormFile formFile)
        {
            try
            {
                var filePath = Path.Combine(Environment.GetFolderPath(wwwroot,"Upload"));

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string imagePath = Path.Combine(filePath, formFile.FileName + ".png");

                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                using (FileStream stream = File.Create(imagePath))
                {
                    await formFile.CopyToAsync(stream);
                }

                // Convert the image to a string representation
                byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
                string imageBase64 = Convert.ToBase64String(imageBytes);
                return imageBase64;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }*/
}
