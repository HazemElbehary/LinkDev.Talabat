using LinkDev.Talabat.Core.Application.MappingProfile;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Application.DepaendancyInjection
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection service)
		{
			service.AddScoped(typeof(MapProfile), typeof(MapProfile));
			return service;
		}
	}
}
