using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.DTOs
{
    public class WalkDTO
    {
        public  Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
    
        public RegionDTO region { get; set; }
        public DifficultyDto difficulty { get; set; }
        
    }
}
