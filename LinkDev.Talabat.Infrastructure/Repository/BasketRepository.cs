using LinkDev.Talabat.Core.Domain.Contracts.Infrastructure;
using LinkDev.Talabat.Core.Domain.Entities.Basket;
using StackExchange.Redis;
using System.Text.Json;

namespace LinkDev.Talabat.Infrastructure.Repository
{
	internal class BasketRepository : IBasketRepository
	{
		private IDatabase _database;

		public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
			_database = connectionMultiplexer.GetDatabase();
		}

        public async Task<CustomerBasket?> GetAsync(string id)
		{
			var Basket = await _database.StringGetAsync(id);

			return Basket.IsNullOrEmpty ? null : 
				JsonSerializer.Deserialize<CustomerBasket>(Basket!);
		}

		public async Task<CustomerBasket?> UpdateAsync(CustomerBasket basket)
		{
			var Basket = await _database
				.StringSetAsync(
					basket.Id,
					JsonSerializer.Serialize(basket.Items)
				);

			return basket;
		}
		
		public async Task<bool> DeleteAsync(string id)
		{
			return await _database.KeyDeleteAsync(id);
		}
	}
}
