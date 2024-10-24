using LinkDev.Talabat.Core.Domain.Entities.Identity;
using LinkDev.Talabat.Infrastructure.Persistence._Identity;
using Microsoft.AspNetCore.Identity;

namespace LinkDev.Talabat.APIs.Extensions
{
	public static class IdentityExtensions
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection service)
		{
			service.AddIdentity<ApplicationUser, IdentityRole>(IdentityOptions => 
			{
				IdentityOptions.User.RequireUniqueEmail = true;

				IdentityOptions.SignIn.RequireConfirmedAccount = true;
				IdentityOptions.SignIn.RequireConfirmedEmail = true;
				IdentityOptions.SignIn.RequireConfirmedPhoneNumber = true;

				IdentityOptions.Password.RequireNonAlphanumeric = true;
				IdentityOptions.Password.RequiredUniqueChars = 2;
				IdentityOptions.Password.RequiredLength = 6;
				IdentityOptions.Password.RequireDigit = true;
				IdentityOptions.Password.RequireUppercase = true;
				IdentityOptions.Password.RequireLowercase = true;

				IdentityOptions.Lockout.AllowedForNewUsers = true;
				IdentityOptions.Lockout.MaxFailedAccessAttempts = 10;
				IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

			}).AddEntityFrameworkStores<StoreIdentityDbContext>();

			return service;
		}
	}
}
