using BikeRentalWebApp.Areas.Roles.Models;
using BikeRentalWebApp.Areas.Users.Models;
using BikeRentalWebApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalWebApp.Areas.Users.Controllers
{
    [Area("Users")]
    public class UserController : Controller
    {
        public UserManager<User> UM { get; set; }
        public RoleManager<Role> RM { get; set; }
        public UserController(UserManager<User> _manager, RoleManager<Role> _Rmanager)
        {
            UM = _manager;
            RM = _Rmanager;
        }
        


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult List()
        {


            return View(UM.Users.ToList());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Edit(string id)
        {

            var UserToEdit = UM.Users.FirstOrDefault(u => u.Id == id);

            return View(UserToEdit);
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(UM.Users.FirstOrDefault(u => u.Id == id));
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Details(string id)
        {

            return View(UM.Users.FirstOrDefault(u => u.Id == id));
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (user == null)
            {
                Warning.warningMessage = "Użytkownik jest nullem";
                return RedirectToAction("List");
            }

            await UM.CreateAsync(user);

            return RedirectToAction("List");

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Edit(User user, List<string> selectedRoles)
        {

            var _user = UM.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if(_user == null) { return RedirectToAction("List"); }
            _user.UserName = user.UserName;
            _user.Email = user.Email;
            _user.PasswordHash = user.PasswordHash;
            _user.PhoneNumber = user.PhoneNumber;
            await UM.UpdateAsync(_user);
            var AllRoles = RM.Roles.ToList();
            IEnumerable<string> rolesString = AllRoles.Select(r => r.Name).ToList()!;
            foreach (string role in rolesString)
            {
                await UM.RemoveFromRoleAsync(_user, role);

            }
            foreach (string role in selectedRoles)
            {
                await UM.AddToRoleAsync(_user, role);

            }
            var Roles = UM.GetRolesAsync(_user);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {
            await UM.DeleteAsync(user);
            return RedirectToAction("List");
        }
    }
}
