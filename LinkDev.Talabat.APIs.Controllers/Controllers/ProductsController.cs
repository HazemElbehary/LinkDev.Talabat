using LinkDev.Talabat.Core.Application.Abstraction.DTOs;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controllers.Controllers
{
	public class ProductsController(IServiceManager serviceManager) : BaseApiController
	{
		[HttpGet]
		public IEnumerable<ProductToReturnDto> GetProducts()
		{
			var Products = serviceManager.ProductService.GetProductsAsync();
			return Products;
		}
	}
}
