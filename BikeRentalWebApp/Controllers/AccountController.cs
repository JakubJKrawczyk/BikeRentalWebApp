using BikeRentalWebApp.Areas.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _um;

        public AccountController(UserManager<User> um)
        {
            _um = um;
        }
        public IActionResult Details()
        {
           
            return View(_um.FindByNameAsync(User.Identity.Name).Result);
        }
        public IActionResult List() {
            return Redirect("/");
        }
    }
}
