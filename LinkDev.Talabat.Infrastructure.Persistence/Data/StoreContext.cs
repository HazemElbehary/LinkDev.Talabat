using LinkDev.Talabat.Core.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Core.Domain.Data
{
    public class StoreContext : DbContext
	{
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
		}
		
		public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
    }
}
