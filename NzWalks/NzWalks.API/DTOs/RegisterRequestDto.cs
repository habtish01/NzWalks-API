using System.ComponentModel.DataAnnotations;

namespace NzWalks.API.DTOs
{
    public class RegisterRequestDto
    {
        [DataType(DataType.EmailAddress)]
        public required string Username { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
