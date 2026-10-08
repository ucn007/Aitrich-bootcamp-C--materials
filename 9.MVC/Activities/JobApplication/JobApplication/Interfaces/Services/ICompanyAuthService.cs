using JobApplication.DTOs.Company;

namespace JobApplication.Interfaces.Services;

public interface ICompanyAuthService
{
    Task<CmpLoginResponseDto?> LoginAsync(CmpLoginDto loginDto);
}