using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Entities.Product;

namespace LinkDev.Talabat.Core.Domain.UnitOfWork
{
	public interface IUnitOfWork
	{
		IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>(string RepositryName) 
			where TEntity : BaseEntity<TKey> 
			where TKey : IEquatable<TKey>;
		Task<int> Complete();
	}
}
