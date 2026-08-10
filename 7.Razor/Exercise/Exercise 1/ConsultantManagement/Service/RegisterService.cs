using ConsultantManagement.Dto;
using ConsultantManagement.Interface;
using ConsultantManagement.Model;
using ConsultantManagement.Repository;

namespace ConsultantManagement.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly RegisterRepository registerRespository;
        public RegisterService(RegisterRepository _registerRespository)
        {
            registerRespository = _registerRespository;
        }
        public async Task AddUserAsync(RegisterDto registerDto)
        {
            await registerRespository.AddUserAsync(registerDto);
        }

        public async Task<Register> GetByUsernameAndPasswordAsync(string Username, string Password)
        {
            return await registerRespository.GetByUsernameAndPasswordAsync(Username, Password);
        }
    }
}
