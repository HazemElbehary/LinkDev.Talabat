using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controllers.Controllers
{
	public class BasketController(IServiceManager serviceManager) : BaseApiController
	{
		[HttpGet]
		public async Task<ActionResult<CustomerBasketDto>> GetBasket(string id)
		{
			var basket = await serviceManager.BasketService.GetCustomerBasketAsync(id);
			return Ok(basket);
		}

		[HttpPost]
		public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basketDto)
		{
			var basket = await serviceManager.BasketService.UpdateCustomerBasketAsync(basketDto);
			return Ok(basket);
		}

		[HttpDelete]
		public async Task DeleteBasket(string id)
		{
			await serviceManager.BasketService.DeleteCustomerBasketAsync(id);
		}
	}
}
