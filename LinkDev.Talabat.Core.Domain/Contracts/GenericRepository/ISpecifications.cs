using LinkDev.Talabat.Core.Domain.Common;
using System.Linq.Expressions;

namespace LinkDev.Talabat.Core.Domain.Contracts.GenericRepository
{
	public interface ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
	{
        // Where [LINQ Operator]
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; set; }
    }
}
