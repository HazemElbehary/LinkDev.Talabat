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


        public BaseISpecifications()
        {
        }

		public BaseISpecifications(TKey id)
		{
			Criteria = E => E.Id.Equals(id);
		}
    }
}
