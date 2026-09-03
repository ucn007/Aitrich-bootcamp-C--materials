using System.ComponentModel.DataAnnotations;
using TourManageDb.Helper;

namespace TourManageDb.DTO
{
    public class RegisterDto
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Gender { get; set; }

    }
}
