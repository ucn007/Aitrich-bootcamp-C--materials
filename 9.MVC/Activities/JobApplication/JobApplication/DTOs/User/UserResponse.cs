namespace JobApplication.DTOs;

public class UserResponseDto
{
    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}