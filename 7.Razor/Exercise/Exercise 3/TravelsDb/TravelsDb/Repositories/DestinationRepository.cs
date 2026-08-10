using TravelsDb.Models;
using TravelsDb.Data;
using TravelsDb.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace TravelsDb.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AppDbContext _context;

        public DestinationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }
        
        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            if (destination != null)
            {
                _context.Destinations.Remove(destination);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
