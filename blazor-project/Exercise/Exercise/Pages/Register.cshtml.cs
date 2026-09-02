using System.ComponentModel.DataAnnotations;
using Exercise.Dtos;
using Exercise.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Pages;

public class RegisterModel : PageModel
{
    private readonly IUserService _userService;

        
    public RegisterModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    [Required]
    [Display(Name = "Full Name")]
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
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var user = new UserCreate
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Password = Password
            };

            await _userService.CreateAsync(user);

            TempData["SuccessMessage"] =
                "Registration successful. Please login.";

            return RedirectToPage("/Login");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("Email", ex.Message);

            return Page();
        }
    }
    

}