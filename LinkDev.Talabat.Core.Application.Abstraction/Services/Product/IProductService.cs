using LinkDev.Talabat.Core.Application.Abstraction.DTOs;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Product
{
	public interface IProductService
	{
		Task<IEnumerable<ProductToReturnDto>> GetProductsAsync();
		Task<ProductToReturnDto> GetProductAsync(int id);

		Task<IEnumerable<BrandToReturnDto>> GetBrandsAsync();
		Task<IEnumerable<CategoryToReturnDto>> GetCategoriesAsync();
	}
}
