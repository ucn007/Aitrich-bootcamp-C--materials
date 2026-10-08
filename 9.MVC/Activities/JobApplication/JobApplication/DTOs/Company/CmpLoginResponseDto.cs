namespace JobApplication.DTOs.Company;

public class CmpLoginResponseDto
{
    public string Token { get; set; } = null!;
    
    public CompanyResponse CompanyResponse { get; set; }= null!;
}