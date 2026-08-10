using Microsoft.EntityFrameworkCore;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;

namespace TourConsultant_login.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;

        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

   

        public async Task<Tour?> GetByIdAsync(Guid id)
        {
            return await _context.Tours.FindAsync(id);
        }

        public async Task AddAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tour = await GetByIdAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _context.Tours
                                 .Include(t => t.Destination)  
                                 .ToListAsync();
        }
    }
}
