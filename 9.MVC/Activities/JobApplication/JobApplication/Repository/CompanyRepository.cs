using JobApplication.Data;
using JobApplication.Interfaces.Repository;
using JobApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Repository;

public class CompanyRepository: ICompanyRepository
{
    private readonly MyDbContext _context;
    public CompanyRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Company?> GetByIdAsync(Guid CompId)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(c => c.CompId == CompId);
    }

    public async Task<Company?> GetByEmailAsync(string email)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<List<Company>> GetAllAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> CreateAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Companies.AnyAsync(c => c.Email == email);
        
    }

    public async Task<Company> UpdateAsync(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<bool> DeleteAsync(Guid compId)
    {
        var company = await GetByIdAsync(compId);

        if (company == null)
        {
            return false;
        }

        _context.Companies.Remove(company);

        await _context.SaveChangesAsync();

        return true;
    }
}