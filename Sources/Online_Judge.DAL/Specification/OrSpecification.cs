using System.Linq;
using Online_Judge.DAL.Extensions;

namespace Online_Judge.DAL.Specification
{
	public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
	{
		public OrSpecification(Specification<TEntity> leftSide, Specification<TEntity> rightSide)
			: base(leftSide, rightSide)
		{
		}

		public override TEntity SatisfyingEntityFrom(IQueryable<TEntity> query)
		{
			return SatisfyingEntitiesFrom(query).FirstOrDefault();
		}

		public override IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query)
		{
			return query.Where(LeftSide.Predicate.Or(RightSide.Predicate));
		}
	}
}
