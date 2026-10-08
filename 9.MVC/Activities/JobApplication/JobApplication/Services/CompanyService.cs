using AutoMapper;
using JobApplication.DTOs.Company;
using JobApplication.Interfaces.Repository;
using JobApplication.Interfaces.Services;
using JobApplication.Models;

namespace JobApplication.Services;

public class CompanyService: ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    
    public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<List<CompanyResponse>> GetAllAsync()
    {
        var companies = await _companyRepository.GetAllAsync();

        return _mapper.Map<List<CompanyResponse>>(companies);
    }

    public async Task<CompanyResponse?> GetByIdAsync(Guid compId)
    {
        return _mapper.Map<CompanyResponse>(await _companyRepository.GetByIdAsync(compId));
    }

    public async Task<CompanyResponse?> RegisterAsync(CmpRegister registerDto)
    {
       var exist = await _companyRepository.GetByEmailAsync(registerDto.Email);
       if (exist != null)
       {
           return null;
       }
       var company = _mapper.Map<Company>(registerDto);
       company.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.PasswordHash);
       company.Email = registerDto.Email;
       
       var createdcompany = await _companyRepository.CreateAsync(company);
       return _mapper.Map<CompanyResponse>(createdcompany);
    }

    public async Task<CompanyResponse?> UpdateAsync(
        Guid userId,
        CmpRegister registerDto)
    {
        var company =
            await _companyRepository.GetByIdAsync(userId);

        if (company == null)
        {
            return null;
        }
       company.CompanyName = registerDto.CompanyName; 
       company.Address = registerDto.Address;
       company.Location = registerDto.Location;
       company.Email = registerDto.Email;
       var updatedCompany = await _companyRepository.UpdateAsync(company);
       return _mapper.Map<CompanyResponse>(updatedCompany);
    }

    public async Task<bool> DeleteAsync(Guid compId)
    {
        var company=   await _companyRepository.GetByIdAsync(compId);
        if (company!= null)
        {
            return false;
        }
        await  _companyRepository.DeleteAsync(compId);
        return true;
    }
    
}