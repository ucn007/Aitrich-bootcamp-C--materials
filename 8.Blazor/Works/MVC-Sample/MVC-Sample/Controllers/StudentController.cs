using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Sample.Models;

namespace MVC_Sample.Controllers;

public class StudentController : Controller
{
    
    private readonly AppDbContext _dbContext;
    
    public StudentController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _dbContext.Students.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _dbContext.Students
            .FirstOrDefaultAsync(x => x.StudentId == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        _dbContext.Students.Update(student);

        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _dbContext.Students.FindAsync(id);
        _dbContext.Students.Remove(book);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}