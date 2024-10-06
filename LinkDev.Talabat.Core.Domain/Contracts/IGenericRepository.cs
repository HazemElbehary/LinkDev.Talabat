using LinkDev.Talabat.Core.Domain.Common;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
	public interface IGenericRepository<TEntity, TKey> 
		where TEntity : BaseEntity<TKey> 
		where TKey : IEquatable<TKey>
	{
		Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);

		Task<TEntity?> GetAsync(TKey Id);

		Task AddAsync(TEntity entity);

		void Updated(TEntity entity);

		void Delete(TEntity entity);
	}
}
