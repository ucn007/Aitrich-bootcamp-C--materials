using System.ComponentModel.DataAnnotations;

namespace BlazorApp5.DTOs;

public class UserUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty; 
    
    
    [EmailAddress] 
    [MaxLength(150)] 
    public string Email { get; set; } = string.Empty; 
    
    
    [Phone] 
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
}