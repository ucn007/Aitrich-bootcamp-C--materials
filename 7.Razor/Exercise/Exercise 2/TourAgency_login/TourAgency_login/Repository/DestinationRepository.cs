using Microsoft.EntityFrameworkCore;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;

namespace TourConsultant_login.Repository
{
    public class DestinationRepository : IDestinationRepository

    {
        private readonly ApplicationDbContext _context;

        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Destination>> GetAllDestinationAsync()
        {
            return await _context.Destination.ToListAsync();
        }

       
    }
}
