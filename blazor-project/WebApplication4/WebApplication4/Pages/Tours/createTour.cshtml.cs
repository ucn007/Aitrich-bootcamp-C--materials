using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
using WebApplication4.Model;
using WebApplication4.Model;

namespace WebApplication4.Pages.Tours;

public class createTour: PageModel
{
    private readonly ApplicationDbContext _context;

    public createTour(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Model.Tours Tour { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Tour.CreatedAt = DateTime.Now;

        _context.Tour.Add(Tour);

        await _context.SaveChangesAsync();

        return RedirectToPage("/Tours/index");
    }
}