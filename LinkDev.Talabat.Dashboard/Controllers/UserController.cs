using LinkDev.Talabat.Core.Domain.Entities.Identity;
using LinkDev.Talabat.Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Dashboard.Controllers
{
	public class UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : Controller
	{
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    DisplayName = u.DisplayName,
                    UserName = u.UserName,
                    PhoneNumber = u.PhoneNumber,
                    Roles = userManager.GetRolesAsync(u).Result
                })
                .ToListAsync();

            return View(users);
        }

        [HttpGet]
		public async Task<IActionResult> Edit(string Id)
		{
			var user = await userManager.FindByIdAsync(Id);
			var allRoles = await roleManager.Roles.ToListAsync();

			var mappedUser = new UserRoleViewModel()
			{
				UserId = user.Id,
				UserName = user.UserName,
				Roles = allRoles.Select
				(
					R => new RoleViewModel() 
					{
						Id = R.Id,
						Name = R.Name,
						IsSeleceted = userManager.IsInRoleAsync(user, R.Name).Result
					}
				).ToList()
			};

			return View(mappedUser);
		}


		[HttpPost]
		public async Task<IActionResult> Edit(string id, UserRoleViewModel model)
		{
			var user = await userManager.FindByIdAsync(id);
			var userRoles = await userManager.GetRolesAsync(user);

			foreach (var role in model.Roles)
			{
				if (userRoles.Any(r => r == role.Name) && !role.IsSeleceted)
					await userManager.RemoveFromRoleAsync(user, role.Name);

                if (!userRoles.Any(r => r == role.Name) && role.IsSeleceted)
                    await userManager.AddToRoleAsync(user, role.Name);
            }
			return RedirectToAction(nameof(Index));
		}

    }
}
