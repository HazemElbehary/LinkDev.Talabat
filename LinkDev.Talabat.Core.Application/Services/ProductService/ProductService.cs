using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;

namespace LinkDev.Talabat.Core.Application.Services.ProductServiceNS
{
	internal class ProductService(IUnitOfWork unitOfWork, Mapper mapper) : IProductService
	{
		public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync()
		{
			var Products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();

			return mapper.Map<IEnumerable<ProductToReturnDto>>(Products);
		}

		public async Task<ProductToReturnDto> GetProductAsync(int id)
		{
			var Product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);

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
