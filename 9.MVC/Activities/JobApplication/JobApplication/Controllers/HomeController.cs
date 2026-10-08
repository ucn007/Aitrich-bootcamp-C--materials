 
using System.Diagnostics;
using JobApplication.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobApplication.Models;

namespace JobApplication.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJobServices _jobService;

    public HomeController(
        ILogger<HomeController> logger,
        IJobServices jobService)
    {
        _logger = logger;
        _jobService = jobService;
    }


    // =========================================================
    // HOME
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var jobs = await _jobService.GetAllAsync();

        return View(jobs);
    }


    // =========================================================
    // PRIVACY
    // =========================================================

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }


    // =========================================================
    // ERROR
    // =========================================================

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId =
                Activity.Current?.Id ??
                HttpContext.TraceIdentifier
        });
    }
}
 