using NzWalks.API.Data;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public class LocalUploadImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor accessor;
        private readonly NzWalksDbContext dbContext;

        public LocalUploadImageRepository(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor accessor,NzWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.accessor = accessor;
            this.dbContext = dbContext;
        }
        public async Task<Image> UploadImage(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, 
                "Images", $"{image.FileName}{image.FileExtension}");
            //upload images to local folder
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);
            //access http://localhost:1040//Images/filename.extension path to save in the database
            var imageUrl = $"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}{accessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

           image.FilePath = imageUrl;
            //save image to database
            await dbContext.images.AddAsync(image);
            await dbContext.SaveChangesAsync();
            return image;

          
        }
    }
}
