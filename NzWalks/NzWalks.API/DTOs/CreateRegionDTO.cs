using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.DTOs
{
    public class CreateRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage="Name should be above 3 characters")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Code should be above 1 characters")]
        [MaxLength(5, ErrorMessage = "Code should be below 6 characters")]
        public string Code { get; set; }
        public string? RegiionImageUrl { get; set; }
    }
}
