using ConsultantManagement.Dto;
using ConsultantManagement.Model;

namespace ConsultantManagement.Interface
{
    public interface IRegisterService
    {
        public Task AddUserAsync(RegisterDto registerDto);
        //public Task<User> LoginAsync(UserDto userDto);
        public Task<Register> GetByUsernameAndPasswordAsync(string Username, string Password);
    }
}
