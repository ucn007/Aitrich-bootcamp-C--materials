using machinetest.Dtos;
using machinetest.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace machinetest.Pages;
[Authorize]
public class IndexModel : PageModel
{
    private readonly IBookService _bookService;

    public IndexModel(IBookService bookService)
    {
        _bookService = bookService;
    }

    public List<BookCreateDto> Books { get; set; } = new();

    public async Task OnGetAsync()
    {
        Books = await _bookService.GetAllAsync();
    }
}