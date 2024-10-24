using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Configurations
{
	internal class BaseConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
		where TEntity : BaseAuditableEntity<TKey>
		where TKey : IEquatable<TKey>

	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.Property(E => E.Id).ValueGeneratedOnAdd();
		}
	}
}
