﻿using LinkDev.Talabat.Core.Domain.Contracts.Infrastructure;
using LinkDev.Talabat.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace LinkDev.Talabat.Infrastructure
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
		{
			services.AddSingleton(typeof(IConnectionMultiplexer), (serviceProvider) =>
			{
				var connectionString = config.GetConnectionString("RedisConnection");

				return ConnectionMultiplexer.ConnectAsync(connectionString!);
			});

			services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

			return services;
		}
    }
}
