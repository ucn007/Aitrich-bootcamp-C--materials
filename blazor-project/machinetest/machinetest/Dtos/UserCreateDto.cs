using System.ComponentModel.DataAnnotations;

namespace machinetest.Dtos;

public class UserCreateDto
{
    [Required]
    public string name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string password { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string phone { get; set; } = string.Empty;
}