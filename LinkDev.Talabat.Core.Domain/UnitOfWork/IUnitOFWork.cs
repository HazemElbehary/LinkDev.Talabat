using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Entities.Product;

namespace LinkDev.Talabat.Core.Domain.UnitOfWork
{
	public interface IUnitOfWork
	{
		public IGenericRepository<Product, int> ProductRepository { get; }
		public IGenericRepository<ProductBrand, int> BrandRepository { get; }
		public IGenericRepository<ProductCategory, int> CategoryRepository { get; }
		Task<int> Complete();
	}
}
