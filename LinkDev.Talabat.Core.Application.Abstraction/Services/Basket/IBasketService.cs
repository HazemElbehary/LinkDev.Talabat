using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Basket;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Basket
{
	public interface IBasketService
	{
		Task<CustomerBasketDto> GetCustomerBasketAsync(string Id);
		Task<CustomerBasketDto> UpdateCustomerBasketAsync(CustomerBasketDto Basket);
		Task DeleteCustomerBasketAsync(string Id);
	}
}
