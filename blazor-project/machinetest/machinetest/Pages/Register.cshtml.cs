using System.ComponentModel.DataAnnotations;
using machinetest.Dtos;
using machinetest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace machinetest.Pages;

public class Register : PageModel
{
    private readonly IUserService _userService;

    public Register(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    [Required]
    public string Name { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            foreach (var item in ModelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    Console.WriteLine(
                        $"FIELD: {item.Key} | ERROR: {error.ErrorMessage}"
                    );
                }
            }

            return Page();
        }

        var emailExists = await _userService.EmailExistsAsync(Email);

        if (emailExists)
        {
            ModelState.AddModelError(
                "Email",
                "A user with this email already exists."
            );

            return Page();
        }

        var dto = new UserCreateDto
        {
            name = Name,
            email = Email,
            phone = Phone,
            password = Password
        };

        try
        {
            await _userService.CreateAsync(dto);

            return RedirectToPage("/Login");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(
                string.Empty,
                ex.InnerException?.Message ?? ex.Message
            );

            return Page();
        }
    }
}