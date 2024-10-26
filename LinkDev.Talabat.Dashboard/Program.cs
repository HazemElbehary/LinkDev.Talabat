using LinkDev.Talabat.Core.Application.MappingProfile;
using LinkDev.Talabat.Core.Domain.Entities.Identity;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using LinkDev.Talabat.Infrastructure.Persistence._Identity;
using LinkDev.Talabat.Infrastructure.Persistence.FUnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Dashboard
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			#region Configure Services

			// Add services to the container.
			builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services
				.AddIdentity<ApplicationUser, IdentityRole>(IdentityOptions =>
			{
				IdentityOptions.User.RequireUniqueEmail = true;

				IdentityOptions.SignIn.RequireConfirmedAccount = true;
				IdentityOptions.SignIn.RequireConfirmedEmail = true;
				IdentityOptions.SignIn.RequireConfirmedPhoneNumber = true;

				IdentityOptions.Lockout.AllowedForNewUsers = true;
				IdentityOptions.Lockout.MaxFailedAccessAttempts = 10;
				IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

			})
				.AddEntityFrameworkStores<StoreIdentityDbContext>();

			builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
			builder.Services.AddAutoMapper(typeof(MapProfile));
			#endregion


			var app = builder.Build();


			#region Configure Middlewares
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Admin}/{action=Login}/{id?}"); 
			#endregion

			app.Run();
		}
	}
}
