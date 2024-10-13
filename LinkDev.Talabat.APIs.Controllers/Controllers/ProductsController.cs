﻿using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controllers.Controllers
{
    public class ProductsController(IServiceManager serviceManager) : BaseApiController
	{

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts(string? sort, int? brandId, int? categoryId)
		{
			var Products = await serviceManager.ProductService.GetProductsAsync(sort, brandId, categoryId);
			return Ok(Products);
		}

		[HttpGet("{Id:int}")]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var Product = await serviceManager.ProductService.GetProductAsync(id);

			if (Product is null)
				return NotFound(new { StatusCode = 404, message = "This Product Is No Found :(" }); 

			return Ok(Product);
		}


		[HttpGet("brands")]
		public async Task<ActionResult<IEnumerable<BrandToReturnDto>>> GetBrands()
		{
			var Brands = await serviceManager.ProductService.GetBrandsAsync();
			return Ok(Brands);
		}


		[HttpGet("categories")]
		public async Task<ActionResult<IEnumerable<CategoryToReturnDto>>> GetCategories()
		{
			var Categories = await serviceManager.ProductService.GetCategoriesAsync();
			return Ok(Categories);
		}

	}
}
