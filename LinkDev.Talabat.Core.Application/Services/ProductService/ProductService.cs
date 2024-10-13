using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using LinkDev.Talabat.Core.Domain.Specifications.Products;

namespace LinkDev.Talabat.Core.Application.Services.ProductServiceNS
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
	{
		public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync(string? sort, int? brandId, int? categoryId, int pageSize, int pageIndex)
		{
			var spec = new ProductWithBrandAndCategorySpecifications(sort, brandId, categoryId, pageSize, pageIndex);

			var Products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);

			return mapper.Map<IEnumerable<ProductToReturnDto>>(Products);
		}

		public async Task<ProductToReturnDto> GetProductAsync(int id)
		{
			var spec = new ProductWithBrandAndCategorySpecifications(id);


			var Product = await unitOfWork.GetRepository<Product, int>().GetWithSpecAsync(spec);

			return mapper.Map<ProductToReturnDto>(Product);
		}

		public async Task<IEnumerable<CategoryToReturnDto>> GetCategoriesAsync()
		{
			var Categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

			return mapper.Map<IEnumerable<CategoryToReturnDto>>(Categories);
		}

		public async Task<IEnumerable<BrandToReturnDto>> GetBrandsAsync()
		{
			var Brnads = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

			return mapper.Map<IEnumerable<BrandToReturnDto>>(Brnads);
		}
	}
}
