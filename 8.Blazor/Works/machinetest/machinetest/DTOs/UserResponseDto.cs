namespace machinetest.DTOs;

public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }
}