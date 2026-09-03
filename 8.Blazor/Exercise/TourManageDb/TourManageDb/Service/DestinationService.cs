using Microsoft.EntityFrameworkCore;
using TourManageDb.Data;
using TourManageDb.Interface;
using TourManageDb.Model;

namespace TourManageDb.Service
{
    public class DestinationService : IDestinationService
    {
        private readonly AppDbContext context;
        public DestinationService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await context.Destinations
                                .OrderBy(x => x.Title)
                                .ToListAsync();
        }
    }
}
