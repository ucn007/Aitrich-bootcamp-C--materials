using JobApplication.DTOs;

namespace JobApplication.Interfaces.Services;

public interface IAuthService
{
   
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
     
}