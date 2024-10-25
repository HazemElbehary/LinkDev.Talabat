using LinkDev.Talabat.Core.Domain.Contracts.DbInitializers;
using LinkDev.Talabat.Core.Domain.Data;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
    public class StoreContextInitializer(StoreContext context) : DbInitializer(context), IStoreContextInitializer
	{
		public override async Task SeedAsync()
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
