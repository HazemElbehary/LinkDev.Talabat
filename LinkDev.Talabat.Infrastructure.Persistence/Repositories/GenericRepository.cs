using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories
{
	public class GenericRepository<TEntity, TKey>(StoreContext dbContext) : IGenericRepository<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
		where TKey : IEquatable<TKey>
	{
		public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
		{
			if (withTracking)
				return await dbContext.Set<TEntity>().ToListAsync();

			return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
		}
		
		public async Task<TEntity?> GetAsync(TKey Id)
		{
			return await dbContext.Set<TEntity>().FindAsync(Id);
		}

		public async Task AddAsync(TEntity entity)
		{
			await dbContext.Set<TEntity>().AddAsync(entity);
		}

		public void Updated(TEntity entity)
		{
			dbContext.Set<TEntity>().Update(entity);
		}

		public void Delete(TEntity entity)
		{
			dbContext.Set<TEntity>().Remove(entity);
		}

	}
}
