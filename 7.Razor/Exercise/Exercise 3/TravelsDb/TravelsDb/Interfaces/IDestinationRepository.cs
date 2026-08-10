using TravelsDb.Models;

namespace TravelsDb.Interfaces
{
    public interface IDestinationRepository
    {
        public Task<List<Destination>> GetAllAsync();
        public Task AddAsync(Destination destination);
        public Task UpdateAsync(Destination destination);
        public Task DeleteAsync(int id);
        public Task SaveAsync();
    }
}
