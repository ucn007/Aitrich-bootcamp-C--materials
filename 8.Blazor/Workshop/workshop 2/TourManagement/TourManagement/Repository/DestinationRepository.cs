using Microsoft.EntityFrameworkCore;
using TourManagement.Interface;
using TourManagement.Model;

namespace TourManagement.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AppDbContext _context;
        public DestinationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Destination destination)
        {
           _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
            //throw new NotImplementedException();
        }
        public async Task<Destination> GetByIdAsync(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }
        public async Task UpdateAsync(Destination destination)
        {
            var existing = await _context.Destinations.FindAsync(destination.Id);

            if (existing != null)
            {
                existing.Name = destination.Name;
                existing.Description = destination.Description;
                existing.ImageUrl = destination.ImageUrl;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);

            if (destination != null)
            {
                _context.Destinations.Remove(destination);
                await _context.SaveChangesAsync();
            }
        }

    }
}
