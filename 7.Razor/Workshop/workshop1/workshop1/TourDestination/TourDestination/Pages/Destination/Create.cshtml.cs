using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TourDestination.Dtos;
using TourDestination.Interfaces;
using TourDestination.Model;

namespace TourDestination.Pages.Destination
{
    //public class CreateModel : PageModel
    //{
    //    private readonly IDestinationService _destinationService;

    //    public CreateModel(IDestinationService destinationService)
    //    {
    //        _destinationService = destinationService;
    //    }

    //    [BindProperty]
    //    public DestinationcreationDto DestinationcreationDto { get; set; } = new();

    //    public void OnGet()
    //    {
    //    }

    //    public async Task<IActionResult> OnPostAsync()
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }

    //        // Await the async call
    //        await _destinationService.CreateAsync(DestinationcreationDto);

    //        TempData["SuccessMessage"] = "Destination registered successfully!";
    //        return RedirectToPage("/Destination/Index");
    //    }
    //}


    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment, IMapper mapper)
        {
            _context = context;
            _environment = environment;
            _mapper = mapper;
        }

        [BindProperty]
        public DestinationcreationDto DestinationDto { get; set; } = new DestinationcreationDto();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Map DTO to entity using AutoMapper
            var destination = _mapper.Map<TourDestination.Model.Destination>(DestinationDto);

            // Handle image upload
            if (DestinationDto.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(DestinationDto.ImageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await DestinationDto.ImageFile.CopyToAsync(fileStream);
                }

                destination.ImagePath = "/images/" + uniqueFileName;
            }

            // Save to database
            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}