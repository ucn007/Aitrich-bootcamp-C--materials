using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Workshop.Dtos;
using Workshop.Interfaces;

namespace Workshop.Pages.Destinations;

public class UpdateModel : PageModel
{
    private readonly IDestinationService _destinationService;

    public UpdateModel(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    [BindProperty]
    public DestinationUpdateDto Destination { get; set; } = new();

    public string? CurrentImagePath { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var destination = await _destinationService.GetByIdAsync(id);

        if (destination == null)
        {
            return NotFound();
        }

        Destination.Id = destination.Id;
        Destination.Name = destination.Name;
        Destination.City = destination.City;

        CurrentImagePath = destination.ImagePath;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Load current image again if validation fails
            var existing = await _destinationService
                .GetByIdAsync(Destination.Id);

            if (existing != null)
            {
                CurrentImagePath = existing.ImagePath;
            }

            return Page();
        }

        var result = await _destinationService.UpdateAsync(Destination);

        if (!result)
        {
            return NotFound();
        }

        return RedirectToPage("/Destinations/Index");
    }
}
