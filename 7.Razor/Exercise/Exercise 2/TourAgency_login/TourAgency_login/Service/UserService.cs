using AutoMapper;
using TourAgency_login.Model;
using TourConsultant_login.Dtos;
using TourConsultant_login.Enum;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Repository;

namespace TourConsultant_login.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Register a new user
        public async Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _repo.GetByUserNameAsync(dto.UserName);
            if (existingUser != null)
                return false;

            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid();
            user.Role = UserRole.CONSULTANT;

            await _repo.AddAsync(user);
            await _repo.SaveAsync();

            return true;
        }

        // Login
        public async Task<User?> LoginAsync(UserLoginDto dto)
        {
            var user = await _repo.GetByUserNameAsync(dto.UserName);
            if (user == null || user.Password != dto.Password)
                return null;

            return user;
        }

        // Change password
        public async Task<bool> ChangePasswordAsync(UserChangePasswordDto dto)
        {
            var user = await _repo.GetByUserNameAsync(dto.UserName);
            if (user == null || user.Password != dto.CurrentPassword)
                return false;

            user.Password = dto.NewPassword;
            await _repo.UpdateAsync(user);
            await _repo.SaveAsync();
            return true;
        }
    }
}
