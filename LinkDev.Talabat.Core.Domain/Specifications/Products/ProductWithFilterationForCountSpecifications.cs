using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories.GenericRepositories;

namespace LinkDev.Talabat.Core.Domain.Specifications.Products
{
	public class ProductWithFilterationForCountSpecifications : BaseISpecifications<Product, int>
	{
        public ProductWithFilterationForCountSpecifications(int? brandId, int? categoryId) : 
            base(
					P =>
					(
					(!brandId.HasValue || P.BrandId == brandId))
						&&
					(!categoryId.HasValue || P.CategoryId == categoryId)
				)
        {
        }
    }
}
