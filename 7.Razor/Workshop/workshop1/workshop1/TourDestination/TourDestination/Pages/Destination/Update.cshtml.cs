using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TourDestination.DestinationDto;
using TourDestination.Model;

namespace TourDestination.Pages.Destination
{
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public UpdateModel(ApplicationDbContext context,
                           IWebHostEnvironment environment,
                           IMapper mapper)
        {
            _context = context;
            _environment = environment;
            _mapper = mapper;
        }

        [BindProperty]
        public DestinationUpdateDto DestinationDto { get; set; }
            = new DestinationUpdateDto();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            if (destination == null)
                return NotFound();

            DestinationDto = _mapper.Map<DestinationUpdateDto>(destination);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var destination = await _context.Destinations
                                            .FirstOrDefaultAsync(d => d.Id == DestinationDto.Id);

            if (destination == null)
                return NotFound();

          
            destination.Name = DestinationDto.Name;
            destination.City = DestinationDto.City;

         
            if (DestinationDto.ImageFile != null &&
                DestinationDto.ImageFile.Length > 0)
            {
                string uploadsFolder =
                    Path.Combine(_environment.WebRootPath, "images");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(DestinationDto.ImageFile.FileName);

                string filePath =
                    Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream =
                       new FileStream(filePath, FileMode.Create))
                {
                    await DestinationDto.ImageFile.CopyToAsync(fileStream);
                }

         
                destination.ImagePath = "/images/" + uniqueFileName;
            }

          

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Destination updated successfully!";

            return RedirectToPage("Index");
        }
    }
}





