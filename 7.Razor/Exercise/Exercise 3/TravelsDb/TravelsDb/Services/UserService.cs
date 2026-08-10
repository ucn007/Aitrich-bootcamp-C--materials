using AutoMapper;
using System.Data;
using TravelsDb.DTO;
using TravelsDb.Interfaces;
using TravelsDb.Models;
using TravelsDb.Repositories;
using TravelsDb.Helper;
using Microsoft.EntityFrameworkCore;

namespace TravelsDb.Services
{
    public class UserService : IUserServices
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

        public async Task RegisterAsync(UserDto dto)
        {
            var user = mapper.Map<User>(dto);

            user.DateTime = DateTime.UtcNow;
            user.Role = dto.Role;

            await userRepository.RegisterAsync(user);
        }
    }
}
