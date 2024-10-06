using LinkDev.Talabat.Core.Domain.ProductNS;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Core.Domain.Data.Configurations
{
	internal class CategoryConfiguration : BaseConfigurations<ProductCategory, int>
	{
		public override void Configure(EntityTypeBuilder<ProductCategory> builder)
		{
			base.Configure(builder);
			builder.Property(C => C.Name).IsRequired();
		}
	}
}
