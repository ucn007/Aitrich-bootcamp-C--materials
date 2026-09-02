using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }
    

    public IList<Model.Doctor> Doctors { get; set; } = new List<Model.Doctor>();

    public async Task OnGetAsync()
    {
        Doctors = await _context.Doctors.ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(x => x.Id == id);

        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}