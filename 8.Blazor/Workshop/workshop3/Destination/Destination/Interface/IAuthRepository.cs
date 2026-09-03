using Destination.Model;

namespace Destination.Interface
{
    public interface IAuthRepository
    {
        Task<Register> GetByEmailAsync(string email);
        Task AddAsync(Register register);
    }
}
