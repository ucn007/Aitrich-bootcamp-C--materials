using System.ComponentModel.DataAnnotations;

namespace BlazorApp5.DTOs;

public class RegisterDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Enter a valid phone number")]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
}