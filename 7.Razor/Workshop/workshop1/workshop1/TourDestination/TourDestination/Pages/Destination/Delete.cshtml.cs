using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TourDestination.Dtos;
using TourDestination.Model;

namespace TourDestination.Pages.Destination
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public DestinationcreationDto DestinationDto { get; set; } = new DestinationcreationDto();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Id == id);

            if (destination == null)
            {
                return NotFound();
            }

            // map entity to DTO
            DestinationDto = _mapper.Map<DestinationcreationDto>(destination);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
