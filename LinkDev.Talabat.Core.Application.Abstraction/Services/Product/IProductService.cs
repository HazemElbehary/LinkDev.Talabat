﻿using LinkDev.Talabat.Core.Application.Abstraction.Common;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Product
{
    public interface IProductService
	{
		Task<Paginations<ProductToReturnDto>> GetProductsAsync(string? sort, int? brandId, int? categoryId, int pageSize, int pageIndex, string? search);
		Task<ProductToReturnDto> GetProductAsync(int id);

		Task<IEnumerable<BrandToReturnDto>> GetBrandsAsync();
		Task<IEnumerable<CategoryToReturnDto>> GetCategoriesAsync();
	}
}
