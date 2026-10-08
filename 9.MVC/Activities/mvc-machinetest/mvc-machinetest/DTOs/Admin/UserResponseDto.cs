namespace mvc_machinetest.DTOs.Admin;

public class UserResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }
}