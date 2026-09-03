using Destination.Interface;
using Destination.Model;
using Microsoft.EntityFrameworkCore;

namespace Destination.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        public AuthRepository(AppDbContext context)
        { 
            _context = context;
        }
        public async Task AddAsync(Register register)
        {
            _context.Registers.Add(register);
            await _context.SaveChangesAsync();
        }

        public async Task<Register> GetByEmailAsync(string email)
        {
            return await _context.Registers.FirstOrDefaultAsync(jp => jp.Email == email);
        }
    }
}
