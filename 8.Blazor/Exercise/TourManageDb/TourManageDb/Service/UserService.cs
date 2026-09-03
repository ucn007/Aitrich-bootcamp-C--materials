using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TourManageDb.DTO;
using TourManageDb.Interface;
using TourManageDb.Model;
using TourManageDb.Service;
using TourManageDb.Helper;


namespace TravelsDb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await userRepository.LoginAsync(email, password);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await userRepository.EmailExistsAsync(email);
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = mapper.Map<User>(dto);

            user.CreatedAt = DateTime.UtcNow;
            user.Role = Role.User;

            await userRepository.RegisterAsync(user);
        }
    }
}
