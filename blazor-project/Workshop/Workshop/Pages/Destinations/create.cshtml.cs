using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Workshop.Dtos;
using Workshop.Interfaces;

namespace Workshop.Pages.Destinations;

public class CreateModel : PageModel
{
    private readonly IDestinationService _destinationService;

    public CreateModel(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    [BindProperty]
    public DestinationCreateDto Destination { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _destinationService.CreateAsync(Destination);

        return RedirectToPage("/Destinations/Index");
    }
}