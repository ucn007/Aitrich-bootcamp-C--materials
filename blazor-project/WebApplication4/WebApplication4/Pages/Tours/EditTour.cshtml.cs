using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Dtos;
using WebApplication4.Service;

namespace WebApplication4.Pages.Tours;

public class EditTour : PageModel
{
    private readonly TourService _service;

    public EditTour(TourService service)
    {
        _service = service;
    }

    [BindProperty]
    public TourDto Tour { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var tour = await _service.GetByIdAsync(id);

        if (tour == null)
        {
            return NotFound();
        }

        Tour = tour;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _service.updateTourAsync(Tour.Id, Tour);

        return RedirectToPage("/Tours/index");
    }
}