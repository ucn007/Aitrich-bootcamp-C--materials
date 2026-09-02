using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages;

public class AppointmentModal: PageModel
{
    private readonly ApplicationDbContext _context;

    public AppointmentModal(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Model.Doctor Doctor { get; set; } = new Model.Doctor();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Doctors.Add(Doctor);
        _context.SaveChanges();

        return RedirectToPage("Index");
    }
}