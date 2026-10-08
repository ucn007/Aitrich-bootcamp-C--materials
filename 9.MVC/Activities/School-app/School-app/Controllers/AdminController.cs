using Microsoft.AspNetCore.Mvc;

namespace School_app.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}