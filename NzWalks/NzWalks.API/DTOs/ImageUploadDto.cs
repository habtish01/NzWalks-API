namespace NzWalks.API.DTOs
{
    public class ImageUploadDto
    {
        public IFormFile File { get; set; }
        public string   FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
