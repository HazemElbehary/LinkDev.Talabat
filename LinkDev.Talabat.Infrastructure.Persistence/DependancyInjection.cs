﻿using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Data;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Domain
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddPresistenceServices(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<StoreContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
			});

			service.AddScoped(typeof(IStoreContextInitializer), typeof(StoreContextInitializer));

			return service;
		}
	}
}
