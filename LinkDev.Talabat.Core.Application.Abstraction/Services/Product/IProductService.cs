using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Product
{
    public interface IProductService
	{
		Task<IEnumerable<ProductToReturnDto>> GetProductsAsync(string? sort, int? brandId, int? categoryId, int pageSize, int pageIndex);
		Task<ProductToReturnDto> GetProductAsync(int id);

		Task<IEnumerable<BrandToReturnDto>> GetBrandsAsync();
		Task<IEnumerable<CategoryToReturnDto>> GetCategoriesAsync();
	}
}
