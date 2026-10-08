namespace JobApplication.DTOs.Company;

public class CmpLoginDto
{
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}