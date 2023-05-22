using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalWebApp.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {

        [Area("Admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
