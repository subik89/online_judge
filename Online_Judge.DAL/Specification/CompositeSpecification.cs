using System.Linq;

namespace Online_Judge.DAL.Specification
{
	/// <summary>
	/// CompositeSpecification class
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class CompositeSpecification<TEntity> : ISpecification<TEntity>
	{
		#region Dependencies

		protected readonly Specification<TEntity> LeftSide;
		protected readonly Specification<TEntity> RightSide;

		#endregion

		#region Constructor

		protected CompositeSpecification(Specification<TEntity> leftSide, Specification<TEntity> rightSide)
		{
			LeftSide = leftSide;
			RightSide = rightSide;
		}

		#endregion

		#region ISpecification<TEntity> Members

		public abstract TEntity SatisfyingEntityFrom(IQueryable<TEntity> query);

		public abstract IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query);

		#endregion
	}
}