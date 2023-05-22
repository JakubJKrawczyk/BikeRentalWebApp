
using BikeRentalWebApp.Areas.Roles.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalWebApp.Areas.Roles.Controllers
{
   
    public class RoleController : Controller
    {
        public RoleManager<Role> RM { get; set; }
        public RoleController(RoleManager<Role> _manager)
        {
            RM = _manager;

        }

        [Area("Roles")]

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult List()
        {


            return View(RM.Roles.ToList());
        }
        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Edit(string id)
        {

            var RoleToEdit = RM.Roles.FirstOrDefault(r => r.Id == id);

            return View(RoleToEdit);
        }
        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(RM.Roles.FirstOrDefault(r => r.Id == id));
        }
        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Details(string id)
        {

            return View(RM.Roles.FirstOrDefault(r => r.Id == id));
        }

        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            if (role == null) return RedirectToAction("List");

            await RM.CreateAsync(role);

            return RedirectToAction("List");

        }
        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Edit(Role role)
        {
            await RM.UpdateAsync(role);
            return RedirectToAction("List");
        }
        [Area("Roles")]
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Delete(Role role)
        {
            await RM.DeleteAsync(role);
            return RedirectToAction("List");
        }


    }
}
