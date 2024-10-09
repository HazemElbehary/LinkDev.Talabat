using LinkDev.Talabat.Core.Application.MappingProfile;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Application.DepaendancyInjection
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection service)
		{
			service.AddAutoMapper(typeof(MapProfile));
			// service.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
			return service;
		}
	}
}
