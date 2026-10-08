using JobApplication.DTOs;
using JobApplication.DTOs.Company;

namespace JobApplication.Interfaces.Services;

public interface ICompanyService
{
    Task<List<CompanyResponse>> GetAllAsync();

    Task<CompanyResponse?> GetByIdAsync(Guid compId);

    Task<CompanyResponse?> RegisterAsync(CmpRegister registerDto);

    Task<CompanyResponse?> UpdateAsync( 
        Guid userId,
        CmpRegister registerDto);

    Task<bool> DeleteAsync(Guid compId);
}