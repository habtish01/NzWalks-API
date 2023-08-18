using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.Models.Domain
{
    public class Walk
    {
        [Key]
        public required Guid Id { get; set; }
        [Required]  
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public required Guid DifficultyId { get; set; }
        public required  Guid RegionId { get; set; }

        //navigate to the classes
        public required Difficulty Difficulty { get; set; }
        public required Region Region { get; set; }

    }
}
