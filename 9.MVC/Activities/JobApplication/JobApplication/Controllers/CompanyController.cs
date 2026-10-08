using JobApplication.DTOs.Company;
using JobApplication.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace JobApplication.Controllers;

public class CompanyController : Controller
{
    private readonly ICompanyAuthService _companyAuthService;
    private readonly ICompanyService _companyService;

    public CompanyController(
        ICompanyAuthService companyAuthService,
        ICompanyService companyService)
    {
        _companyAuthService = companyAuthService;
        _companyService = companyService;
    }

    // =========================
    // LOGIN
    // =========================

    
    [HttpGet] 
    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(CmpLoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        var result = await _companyAuthService.LoginAsync(loginDto);

        if (result == null)
        {
            ModelState.AddModelError(
                "",
                "Invalid email or password."
            );

            return View(loginDto);
        }

        Response.Cookies.Append("jwt", result.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });

        return RedirectToAction("Index" ,"Company");
    }
    // =========================
    // REGISTER
    // =========================

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(CmpRegister registerDto)
    {
        // =========================
        // CHECK MODEL VALIDATION
        // =========================

        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState)
            {
                foreach (var message in error.Value.Errors)
                {
                    var errorMessage = message.ErrorMessage;

                    Console.WriteLine(
                        $"Register Error | Property: {error.Key} | Error: {errorMessage}"
                    );
                }
            }

            // Show validation errors on the page
            return View(registerDto);
        }

        // =========================
        // REGISTER COMPANY
        // =========================

        try
        {
            var result =
                await _companyService.RegisterAsync(registerDto);

            if (result == null)
            {
                const string errorMessage =
                    "A company with this email already exists.";

                // Console
                Console.WriteLine(
                    $"Register Error | {errorMessage}"
                );

                // Page
                ModelState.AddModelError(
                    "",
                    errorMessage
                );

                return View(registerDto);
            }

            Console.WriteLine(
                $"Company registered successfully | Email: {registerDto.Email}"
            );

            return RedirectToAction(nameof(Login));
        }
        catch (Exception ex)
        {
            // Console
            Console.WriteLine(
                $"Register Exception | {ex.Message}"
            );

            Console.WriteLine(
                $"Stack Trace | {ex.StackTrace}"
            );

            // Page
            ModelState.AddModelError(
                "",
                "An unexpected error occurred while registering the company."
            );

            return View(registerDto);
        }
    }

    // =========================
    // DASHBOARD
    // =========================

    [HttpGet]
    [Authorize(Roles = "Company")]
    public IActionResult Dashboard()
    {
        return View();
    }


    // =========================
    // LOGOUT
    // =========================

    [HttpPost]
    [Authorize(Roles = "Company")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");

        return RedirectToAction("Login");
    }
}