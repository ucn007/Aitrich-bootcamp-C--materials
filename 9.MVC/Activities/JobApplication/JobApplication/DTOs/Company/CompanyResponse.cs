namespace JobApplication.DTOs.Company;

public class CompanyResponse
{
    public Guid CompId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Email { get; set; } = null!;
}