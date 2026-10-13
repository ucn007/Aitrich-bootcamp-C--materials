using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers;

public class AdminController : Controller
{
    // GET
   
        public IActionResult Index()
        {
            return View();
        }
     
}