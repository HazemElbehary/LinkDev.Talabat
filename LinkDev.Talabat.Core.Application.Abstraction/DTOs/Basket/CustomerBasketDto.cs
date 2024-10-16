namespace LinkDev.Talabat.Core.Application.Abstraction.DTOs.Basket
{
	public class CustomerBasketDto
	{
		public int Id { get; set; }
		public IEnumerable<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
	}
}
