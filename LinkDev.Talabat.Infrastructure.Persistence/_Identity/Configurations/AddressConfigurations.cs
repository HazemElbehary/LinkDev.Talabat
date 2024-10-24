using LinkDev.Talabat.Core.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Identity.Configurations
{
	internal class AddressConfigurations : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.Property(A => A.Id).ValueGeneratedOnAdd();
			builder.Property(A => A.FirstName).HasMaxLength(50);
			builder.Property(A => A.LastName).HasMaxLength(50);
			builder.Property(A => A.Street).HasMaxLength(50);
			builder.Property(A => A.City).HasMaxLength(50);
			builder.Property(A => A.Country).HasMaxLength(50);
		}
	}
}
