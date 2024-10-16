using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Core.Application.MappingProfile;
using LinkDev.Talabat.Core.Application.Services;
using LinkDev.Talabat.Core.Application.Services.Basket;
using LinkDev.Talabat.Core.Domain.Contracts.Infrastructure;
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

			service.AddScoped(typeof(Func<IBasketService>), (serviceProvider) =>
			{
				var mapper = serviceProvider.GetRequiredService<IMapper>();
				var configuration = serviceProvider.GetRequiredService<IConfiguration>();
				var basket = serviceProvider.GetRequiredService<IBasketRepository>();
				return new BasketService(basket, mapper, configuration);

			});

			return service;
		}
	}
}
