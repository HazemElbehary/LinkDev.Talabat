using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Data;
using LinkDev.Talabat.Core.Domain.UnitOfWork;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork, IAsyncDisposable
	{
		private readonly StoreContext _dbContext;
		ConcurrentDictionary<string, object> Repositories;

		public UnitOfWork(StoreContext context)
        {
			_dbContext = context;
			Repositories = new ();
		}

		public async Task<int> Complete()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>(string RepositryName)
			where TEntity : BaseEntity<TKey>
			where TKey : IEquatable<TKey>
		{
			return (GenericRepository<TEntity, TKey>)Repositories.GetOrAdd(RepositryName, new GenericRepository<TEntity, TKey>(_dbContext));
		}
	}
}