using AutoMapper;
using Destination.Dto;
using Destination.Interface;
using Destination.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Destination.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _AuthRepo;
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IMapper _mapper;
        public AuthService(IAuthRepository AuthRepo, ProtectedSessionStorage sessionStorage, IMapper mapper)
        {
            _AuthRepo = AuthRepo;
            _sessionStorage = sessionStorage;
            _mapper = mapper;
        }
        public async Task<bool> Login(string email, string password)
        {
            var register = await _AuthRepo.GetByEmailAsync(email);
            if (register == null || !BCrypt.Net.BCrypt.Verify(password, register.PasswordHash))
                return false;

            try
            {
                await _sessionStorage.SetAsync("RegisterId", register.Id);
                await _sessionStorage.SetAsync("RegisterEmail", register.Email);
                Console.WriteLine("Session stored successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Session error: " + ex.ToString());
            }

            return true;
        }

        public async Task Logout()
        {
            await _sessionStorage.DeleteAsync("RegisterId");
            await _sessionStorage.DeleteAsync("RegisterEmail");
        }

        public async Task<bool> Register(RegisterDto registerDto, string password)
        {
            var existingProvider = await _AuthRepo.GetByEmailAsync(registerDto.Email);
            if (existingProvider != null)
                return false;

            var register = _mapper.Map<Register>(registerDto);
            register.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            await _AuthRepo.AddAsync(register);
            return true;
        }
    }
}
