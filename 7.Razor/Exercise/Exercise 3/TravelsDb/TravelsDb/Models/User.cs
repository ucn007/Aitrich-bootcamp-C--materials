using System.ComponentModel.DataAnnotations;
using TravelsDb.Helper;

namespace TravelsDb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public DateTime DateTime { get; set; }= DateTime.UtcNow;
        public Role Role { get; set; }
    }
}
