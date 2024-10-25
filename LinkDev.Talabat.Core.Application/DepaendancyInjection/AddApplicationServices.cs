using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Core.Application.MappingProfile;
using LinkDev.Talabat.Core.Application.Services;
using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Application.Services.Basket;
using LinkDev.Talabat.Core.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Application.DepaendancyInjection
{
    public static class DependancyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection service)
		{
			service.AddAutoMapper(typeof(MapProfile));
			service.AddScoped(typeof(IServiceManager), typeof(ServiceManager));


			service.AddScoped(typeof(IBasketService), typeof(BasketService));
			service.AddScoped(typeof(Func<IBasketService>), (serviceProvider) =>
			{
				return () => serviceProvider.GetRequiredService<IBasketService>();
			});


			service.AddScoped(typeof(IAuthService), typeof(AuthService));
			service.AddScoped(typeof(Func<IAuthService>), (serviceProvider) => 
			{
				return () => serviceProvider.GetRequiredService<IAuthService>();
			});

			return service;
		}
	}
}
