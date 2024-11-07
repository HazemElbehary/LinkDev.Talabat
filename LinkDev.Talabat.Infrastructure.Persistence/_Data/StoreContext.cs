using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence.Common;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LinkDev.Talabat.Core.Domain.Data
{
    public class StoreContext : DbContext
	{
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
				typeof(AssemblyInformation).Assembly,
				type => type.GetCustomAttribute<DbContextTypeAttribute>()?.DbContextType == typeof(StoreContext)
			);
		}

		public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
    }
}
