using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages.Doctor;

public class EditDoctor: PageModel
{
    private readonly ApplicationDbContext _context;

    public EditDoctor(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Model.Doctor Doctor { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);

        if (doctor == null)
        {
            return NotFound();
        }

        Doctor = doctor;

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingDoctor = _context.Doctors
            .FirstOrDefault(x => x.Id == Doctor.Id);

        if (existingDoctor == null)
        {
            return NotFound();
        }

        existingDoctor.Name = Doctor.Name;
        existingDoctor.Email = Doctor.Email;
        existingDoctor.Department = Doctor.Department;
        existingDoctor.Phone = Doctor.Phone;

        _context.SaveChanges();

        return RedirectToPage("../Index");
    }
}