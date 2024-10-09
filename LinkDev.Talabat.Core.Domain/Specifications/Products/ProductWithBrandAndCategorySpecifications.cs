using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories.GenericRepositories;

namespace LinkDev.Talabat.Core.Domain.Specifications.Products
{
	public class ProductWithBrandAndCategorySpecifications : BaseISpecifications<Product, int>
	{
        public ProductWithBrandAndCategorySpecifications() : base()
        {
			Includes.Add(P => P.Brand!);
			Includes.Add(P => P.Category!);
		}
    }
}
