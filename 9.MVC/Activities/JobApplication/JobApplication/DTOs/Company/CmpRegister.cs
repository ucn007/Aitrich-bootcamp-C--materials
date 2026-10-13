namespace JobApplication.DTOs.Company;

public class CmpRegister
{
    public Guid CompId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;
}