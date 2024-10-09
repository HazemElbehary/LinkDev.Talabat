using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;

namespace LinkDev.Talabat.Core.Application.Services.ProductService
{
	internal class ProductService(IUnitOfWork unitOfWork, Mapper mapper) : IProductService
	{
		public IEnumerable<ProductToReturnDto> GetProductsAsync()
		{
			var Products = unitOfWork.GetRepository<Product, int>().GetAllAsync();

			return mapper.Map<IEnumerable<ProductToReturnDto>>(Products);
		}

		public ProductToReturnDto GetProductAsync(int id)
		{
			var Product = unitOfWork.GetRepository<Product, int>().GetAsync(id);

			return mapper.Map<ProductToReturnDto>(Product);
		}

		public IEnumerable<CategoryToReturnDto> GetCategoriesAsync()
		{
			var Categories = unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

			return mapper.Map<IEnumerable<CategoryToReturnDto>>(Categories);
		}

		public IEnumerable<BrandToReturnDto> GetBrandsAsync()
		{
			var Brnads = unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

			return mapper.Map<IEnumerable<BrandToReturnDto>>(Brnads);
		}
	}
}
