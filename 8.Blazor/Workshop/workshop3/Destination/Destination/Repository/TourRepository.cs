using Destination.Data;
using Destination.Interface;
using Destination.Model;
using Microsoft.EntityFrameworkCore;

namespace Destination.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTourAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tour>> GetAllToursAsync()
        {
            return await _context.Tours.ToListAsync();
        }
    }
}