using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TourDestination.Model;  // Important!

namespace TourDestination.Pages.Destination
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // ? This is your list of destinations
        public List<TourDestination.Model.Destination> DestinationList { get; set; } = new List<TourDestination.Model.Destination>();


        public async Task OnGetAsync()
        {
            DestinationList = await _context.Destinations.ToListAsync();
        }
    }
}


