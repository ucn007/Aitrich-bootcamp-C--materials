using Microsoft.EntityFrameworkCore;
using TourManageDb.Data;
using TourManageDb.Interface;
using TourManageDb.Model;

namespace TourManageDb.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext context;
        public TourRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Tour>> GetAllAsync()
        {
            return await context.Tours
                .Include(t => t.Destination)
                .ToListAsync();
        }
        public async Task<Tour?> GetByIdAsync(int id)
        {
            return await context.Tours
                .Include(t => t.Destination)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task AddTourAsync(Tour tour)
        {
            await context.Tours.AddAsync(tour);
        }
        public async Task UpdateTourAsync(Tour tour)
        {
            context.Tours.Update(tour);
        }
        public async Task DeleteTourAsync(int id)
        {
            var tour = await GetByIdAsync(id);
            if (tour != null)
            {
                context.Tours.Remove(tour);
            }
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


    }
}
