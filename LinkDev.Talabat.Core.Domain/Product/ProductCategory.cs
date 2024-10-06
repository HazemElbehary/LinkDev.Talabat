using LinkDev.Talabat.Core.Domain.Common;

namespace LinkDev.Talabat.Core.Domain.ProductNS
{
	public class ProductCategory : BaseEntity<int>
	{
		public required string Name { get; set; }
	}
}
