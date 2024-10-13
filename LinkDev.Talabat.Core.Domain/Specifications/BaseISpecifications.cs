using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts.GenericRepository;
using System.Linq.Expressions;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories.GenericRepositories
{
	public class BaseISpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
		where TKey : IEquatable<TKey>
	{
		// Where 'LINQ Operator'
		public Expression<Func<TEntity, bool>>? Criteria { get ; set; }
		public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
		public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
		public Expression<Func<TEntity, object>>? OrderByDesc { get; set; } = null;

		public BaseISpecifications()
        {
        }

		public BaseISpecifications(TKey id)
		{
			Criteria = E => E.Id.Equals(id);
		}

		private protected virtual void AddIncludes()
		{

		}

		private protected virtual void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression)
		{
			OrderBy = OrderByExpression;
		}

		private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExpression)
		{
			OrderByDesc = OrderByDescExpression;
		}
	}
}
