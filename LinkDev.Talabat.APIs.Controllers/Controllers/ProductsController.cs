using LinkDev.Talabat.Core.Application.Abstraction.DTOs;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controllers.Controllers
{
	public class ProductsController(IServiceManager serviceManager) : BaseApiController
	{

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
		{
			var Products = await serviceManager.ProductService.GetProductsAsync();
			return Ok(Products);
		}

		[HttpGet("{Id: int}")]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var Product = await serviceManager.ProductService.GetProductAsync(id);

			if (Product is null)
				return NotFound(new { StatusCode = 404, message = "This Product Is No Found :(" }); 

			return Ok(Product);
		}
	}
}
