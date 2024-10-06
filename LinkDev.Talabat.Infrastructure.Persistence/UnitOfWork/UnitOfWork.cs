using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Data;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Core.Domain.UnitOfWork;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork ,IAsyncDisposable
	{
		private readonly StoreContext _dbContext;
		private readonly Lazy<IGenericRepository<Product, int>> productRepository;
		private readonly Lazy<IGenericRepository<ProductBrand, int>> brandRepository;
		private readonly Lazy<IGenericRepository<ProductCategory, int>> categoryRepository;


		public UnitOfWork(StoreContext context)
        {
			_dbContext = context;
			productRepository = new Lazy<IGenericRepository<Product, int>>(new GenericRepository<Product, int>(_dbContext));
			brandRepository = new Lazy<IGenericRepository<ProductBrand, int>>(new GenericRepository<ProductBrand, int>(_dbContext));
			categoryRepository = new Lazy<IGenericRepository<ProductCategory, int>>(new GenericRepository<ProductCategory, int>(_dbContext));
		}

		public IGenericRepository<Product, int> ProductRepository  => productRepository.Value;
		public IGenericRepository<ProductBrand, int> BrandRepository => brandRepository.Value; 
		public IGenericRepository<ProductCategory, int> CategoryRepository => categoryRepository.Value;

		public async Task<int> Complete()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}
	}
}
