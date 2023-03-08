using Microsoft.AspNetCore.Mvc;

namespace BikeRentalWebApp.Controllers;

public class VechiclesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}