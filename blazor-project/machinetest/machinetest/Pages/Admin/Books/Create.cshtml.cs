using machinetest.Dtos;
using machinetest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace machinetest.Pages.Admin.Books;

public class Create : PageModel
{
    private readonly IBookService _bookService;

    public Create(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty]
    public BookCreateDto Book { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _bookService.CreateAsync(Book);

        return RedirectToPage("/Admin/Index");
    }
} 