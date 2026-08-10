using Microsoft.EntityFrameworkCore;
using TourDestination.Interfaces;
using TourDestination.Model;

namespace TourDestination.Repositories
{

    public class DestinationRepository : IDestinationRepository
    {
        
        
            private readonly ApplicationDbContext _db;

            public DestinationRepository(ApplicationDbContext db) => _db = db;

            public async Task AddAsync(Destination destination)
            {
                _db.Destinations.Add(destination);
                await _db.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var entity = await _db.Destinations.FindAsync(id);
                if (entity != null)
                {
                    _db.Destinations.Remove(entity);
                    await _db.SaveChangesAsync();
                }
            }

            public async Task<List<Destination>> GetAllAsync()
                => await _db.Destinations.AsNoTracking().ToListAsync();

            public async Task<Destination?> GetByIdAsync(int id)
                => await _db.Destinations.FindAsync(id);

            public async Task UpdateAsync(Destination destination)
            {
                _db.Destinations.Update(destination);
                await _db.SaveChangesAsync();
            }

            public async Task<bool> ExistsAsync(int id)
                => await _db.Destinations.AnyAsync(d => d.Id == id);
        }
    }


