using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.MappingProfile;
using LinkDev.Talabat.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Application.DepaendancyInjection
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection service)
		{
			service.AddScoped(typeof(MapProfile), typeof(MapProfile));
			service.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
			return service;
		}
	}
}
