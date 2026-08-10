using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelsDb.Interfaces;
using TravelsDb.Models;

namespace TravelsDb.Pages.Work
{
    public class IndexModel : PageModel
    {
        private readonly IDestinationService _service;
        private readonly IWebHostEnvironment _environment;

        public IndexModel(IDestinationService service,
                          IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        // List for displaying cards
        public List<Destination> Destinations { get; set; } = new();

        // Bind form data
        [BindProperty]
        public Destination Destination { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        // Load destinations
        public async Task<IActionResult> OnGetAsync()
        {
            var username = HttpContext.Session.GetString("UserName");
            if(username == null)
            {
                return RedirectToPage("/Account/Login");
            }
            Destinations = await _service.GetAllAsync();
            return Page();
        }

        // Add destination
        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("UserRole");

            if(role != "Admin")
            {
                return Forbid();
            }
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Field: {entry.Key} - Error: {error.ErrorMessage}");
                    }
                }
                Destinations = await _service.GetAllAsync();
                return Page();
            }

            if (ImageFile != null)
            {
                string uploads = Path.Combine(_environment.WebRootPath, "images");

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                string fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string path = Path.Combine(uploads, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await ImageFile.CopyToAsync(stream);

                Destination.ImagePath = "/images/" + fileName;
            }

            await _service.AddAsync(Destination);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(
            int Id,
            string Name,
            string Description,
            IFormFile? ImageFile)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin")
            {
                return Forbid();
            }
            var destination = (await _service.GetAllAsync()).FirstOrDefault(d => d.Id == Id);

            if (destination == null)
            {
                return NotFound();
            }
            destination.Name = Name;
            destination.Description = Description;

            if (ImageFile != null)
            {
                string uploads = Path.Combine(_environment.WebRootPath, "images");

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                string fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string path = Path.Combine(uploads, fileName);

                using var stream = new FileStream(path, FileMode.Create);

                await ImageFile.CopyToAsync(stream);
                destination.ImagePath = "/images/" + fileName;
            }
            await _service.UpdateAsync(destination);
            return RedirectToPage();
        }

        // Delete destination
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin")
            {
                return Forbid();
            }
            await _service.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}