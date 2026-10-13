using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobApplication.Configuration;
using JobApplication.DTOs.Company;
using JobApplication.Interfaces.Repository;
using JobApplication.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JobApplication.Services;

public class CompanyAuthService : ICompanyAuthService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly JwtSettings _jwtSettings;

    public CompanyAuthService(
        ICompanyRepository companyRepository,
        IOptions<JwtSettings> jwtSettings)
    {
        _companyRepository = companyRepository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<CmpLoginResponseDto?> LoginAsync(
        CmpLoginDto loginDto)
    {
        // Find company by email
        var company = await _companyRepository
            .GetByEmailAsync(loginDto.Email);

        if (company == null)
        {
            return null;
        }

        // Verify password
        var passwordValid = BCrypt.Net.BCrypt.Verify(
            loginDto.PasswordHash,
            company.PasswordHash
        );

        if (!passwordValid)
        {
            return null;
        }

        // Generate JWT
        var token = GenerateToken(company);

        return new CmpLoginResponseDto
        {
            Token = token,

            CompanyResponse = new CompanyResponse
            {
                CompId = company.CompId,
                CompanyName = company.CompanyName,
                Address = company.Address,
                Location = company.Location,
                Email = company.Email
            }
        };
    }

  
    private string GenerateToken(Models.Company company)
    {
        var claims = new List<Claim>
        {
            // Company ID
            new Claim(
                "CompId",
                company.CompId.ToString()
            ),

            // Also identify the authenticated user
            new Claim(
                ClaimTypes.NameIdentifier,
                company.CompId.ToString()
            ),

            // Company email
            new Claim(
                ClaimTypes.Email,
                company.Email
            ),

            // Company name
            new Claim(
                ClaimTypes.Name,
                company.CompanyName
            ),

            // Role
            new Claim(
                ClaimTypes.Role,
                "Company"
            )
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                _jwtSettings.ExpiryMinutes
            ),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
    

}