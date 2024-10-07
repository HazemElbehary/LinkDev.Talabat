using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Data;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
	public class StoreContextInitializer(StoreContext context) : IStoreContextInitializer
	{
        public async Task InitializeAsync()
		{
			var Migrations = await context.Database.GetPendingMigrationsAsync();

			if (Migrations.Any())
				await context.Database.MigrateAsync();
		}

		public async Task SeedAsync()
		{
			if (context.Brands.Count() == 0)
			{
				var Brands = File.ReadAllText("../LinkDev.Talabat.Core.Domain/Data/Seeds/brands.json");
				var BrandsList = JsonSerializer.Deserialize<List<ProductBrand>>(Brands);
				if (BrandsList?.Count > 0)
					await context.Brands.AddRangeAsync(BrandsList);

				var Categories = File.ReadAllText("../LinkDev.Talabat.Core.Domain/Data/Seeds/categories.json");
				var CategoriesList = JsonSerializer.Deserialize<List<ProductCategory>>(Categories);
				if (CategoriesList?.Count > 0)
					await context.Categories.AddRangeAsync(CategoriesList);

				var Products = File.ReadAllText("../LinkDev.Talabat.Core.Domain/Data/Seeds/products.json");
				var ProductsList = JsonSerializer.Deserialize<List<Product>>(Products);
				if (ProductsList?.Count > 0)
					await context.products.AddRangeAsync(ProductsList);

				await context.SaveChangesAsync(); 
			}
		}
	}
}
