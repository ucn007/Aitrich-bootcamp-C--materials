using JobApplication.Models;

namespace JobApplication.Interfaces.Repository;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(Guid userId);
    
    Task<Company?> GetByEmailAsync(string email);
    
    Task<List<Company>> GetAllAsync();
    
    Task<Company> CreateAsync(Company company);
    
    Task<bool> EmailExistsAsync(string email);
    
    Task<Company> UpdateAsync(Company company);
    
    Task<bool> DeleteAsync(Guid userId);
}