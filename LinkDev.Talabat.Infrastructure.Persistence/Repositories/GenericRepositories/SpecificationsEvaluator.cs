using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories.GenericRepositories
{
	public static class SpecificationsEvaluator<TEntity, TKey> 
		where TEntity : BaseEntity<TKey> 
		where TKey : IEquatable<TKey>
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> entities, ISpecifications<TEntity, TKey> spec)
		{
			if (spec.Criteria is not null)
				entities.Where(spec.Criteria);

            foreach (var Include in spec.Includes)
            {
				entities.Include(Include);
            }

			return entities;
		}
	}
}
