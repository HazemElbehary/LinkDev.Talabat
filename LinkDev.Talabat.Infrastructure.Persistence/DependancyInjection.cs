﻿using LinkDev.Talabat.Core.Domain.Contracts.DbInitializers;
using LinkDev.Talabat.Core.Domain.Data;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using LinkDev.Talabat.Infrastructure.Persistence._Identity;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Interceptors;
using LinkDev.Talabat.Infrastructure.Persistence.FUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
				options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("StoreConnection"));
			});


			service.AddDbContext<StoreIdentityDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
			});

			service.AddScoped(typeof(IStoreContextInitializer), typeof(StoreContextInitializer));
			service.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptor));
			service.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
			
			
			return service;
		}
	}
}
