using LinkDev.Talabat.Core.Domain.Common;

namespace LinkDev.Talabat.Core.Domain.ProductNS
{
	public class ProductBrand : BaseEntity<int>
	{
        public required string Name { get; set; }
    }
}
