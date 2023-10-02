using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;
using NzWalks.API.Repositories;

namespace NzWalks.API.Controllers
{
   
    public class ImagesController : BaseController
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] ImageUploadDto imageUpload)
        {
            ValidateImageFile(imageUpload);
            if (ModelState.IsValid)
            {
                // convert dto to image model
                var imageupload = new Image
                {
                    File = imageUpload.File,
                    FileExtension = Path.GetExtension(imageUpload.File.FileName),
                    FileName = imageUpload.FileName,
                    FileDescription = imageUpload.FileDescription,
                    FileSizeInBytes = imageUpload.File.Length
                };
                //image upload repository
                await imageRepository.UploadImage(imageupload);
                return Ok(imageupload);

            }
            return BadRequest(ModelState);
        }

        private void ValidateImageFile(ImageUploadDto imageUpload)
        {
            var imageExtensions = new List<string>
            {
                ".jpg",
                ".png",
                ".jped"

            };

            if (!imageExtensions.Contains(Path.GetExtension(imageUpload.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported File extension");
            }
            if(imageUpload.File.Length> 1048576)
            {
                ModelState.AddModelError("File", "File Size greater Than 10mb! try another one");
            }
        }
    }
}
