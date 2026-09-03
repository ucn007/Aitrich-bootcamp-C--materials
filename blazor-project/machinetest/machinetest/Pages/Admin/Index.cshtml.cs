using machinetest.Dtos;
using machinetest.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace machinetest.Pages.Admin;

public class Index : PageModel
{
    private readonly IBookService _bookService;

    public Index(IBookService bookService)
    {
        _bookService = bookService;
    }

    public List<BookCreateDto> Books { get; set; } = new();

    public async Task OnGetAsync()
    {
        Books = await _bookService.GetAllAsync();
    }
}