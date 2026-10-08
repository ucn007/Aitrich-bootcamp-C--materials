using System.ComponentModel.DataAnnotations;

namespace Education.DTOs.User;

public class UpdateUserDto
{
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Phone { get; set; } = null!;

    [Required]
    public string Gender { get; set; } = null!;
}