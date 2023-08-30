using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.DTOs
{
    public class CreateWalkDTO
    {

        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        [Range(0,100,ErrorMessage ="the length of the walks in KM should be above 0 and below 100")]
        public required double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public required Guid DifficultyId { get; set; }
        [Required]
        public required Guid RegionId { get; set; }
    }
}
