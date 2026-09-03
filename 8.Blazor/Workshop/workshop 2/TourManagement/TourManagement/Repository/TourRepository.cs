using Microsoft.EntityFrameworkCore;
using TourManagement.Interface;
using TourManagement.Model;

namespace TourManagement.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _context;
        public TourRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Tour tour)
        {
            //throw new NotImplementedException();
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _context.Tours
        .Include(t => t.TDestination)
        .ToListAsync();

            //throw new NotImplementedException();
        }
    }
}
