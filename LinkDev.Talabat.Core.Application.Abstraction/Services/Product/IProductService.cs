using LinkDev.Talabat.Core.Application.Abstraction.DTOs;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Product
{
	public interface IProductService
	{
		IEnumerable<ProductToReturnDto> GetProductsAsync();
		ProductToReturnDto GetProductAsync(int id);

		IEnumerable<BrandToReturnDto> GetBrandsAsync();
		IEnumerable<CategoryToReturnDto> GetCategoriesAsync();
	}
}
