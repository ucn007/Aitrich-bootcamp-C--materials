using AutoMapper;
using ConsultantManagement.Dto;
using ConsultantManagement.Interface;
using ConsultantManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsultantManagement.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RegisterRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddUserAsync(RegisterDto registerDto)
        {
            var register = _mapper.Map<Register>(registerDto);
            _context.Registers.Add(register);
            await _context.SaveChangesAsync();
        }

        public async Task<Register> GetByUsernameAndPasswordAsync(string Username, string Password)
        {
            return await _context.Registers
    .SingleOrDefaultAsync(u => u.Username == Username && u.Password == Password);
        }
    }
}
