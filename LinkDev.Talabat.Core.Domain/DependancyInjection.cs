using LinkDev.Talabat.Core.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Domain
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<StoreContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
			});

			return service;
		}
	}
}
