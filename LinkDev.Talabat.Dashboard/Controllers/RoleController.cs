﻿using LinkDev.Talabat.Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Dashboard.Controllers
{
    public class RoleController(RoleManager<IdentityRole> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var Roles = await roleManager.Roles.ToListAsync();
			return View(Roles);
        }

		[HttpPost]
		public async Task<IActionResult> Create(RoleFormViewModel model)
		{
			if (ModelState.IsValid)
			{
				var roleExists = await roleManager.RoleExistsAsync(model.Name);
				if (!roleExists)
				{
					await roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ModelState.AddModelError("Name", "Role is already exist");
					return View("Index", await roleManager.Roles.ToListAsync());
				}
			}

			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> Delete(string id)
		{
			var role = await roleManager.FindByIdAsync(id);
			await roleManager.DeleteAsync(role!);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(string id)
		{
			var role = await roleManager.FindByIdAsync(id);
			var mappedRole = new RoleViewModel() { Name = role.Name };

			return View(mappedRole);
		}

        [HttpPost]
		public async Task<IActionResult> Edit(string id, RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await roleManager.RoleExistsAsync(model.Name);
                if (!roleExists)
                {
                    var role = await roleManager.FindByIdAsync(model.Id);
					role.Name = model.Name;
					await roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Name", "Role is already exist");
                    return View("Index", await roleManager.Roles.ToListAsync());
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
