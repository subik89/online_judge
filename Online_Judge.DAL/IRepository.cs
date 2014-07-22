using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Online_Judge.DAL.Specification;

namespace Online_Judge.DAL
{
	/// <summary>
	/// IRepository interface
	/// </summary>
	public interface IRepository
	{
		/// <summary>
		/// Gets the query.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <returns></returns>
		IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;

		/// <summary>
		/// Gets the query.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		IQueryable<TEntity> GetQuery<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Gets single entity using specification
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		TEntity Single<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Singles the or default.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		TEntity SingleOrDefault<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Gets first entity with specification.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		TEntity First<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Firsts the or default.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		TEntity FirstOrDefault<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="entity">The entity.</param>
		void Add<TEntity>(TEntity entity) where TEntity : class;

		/// <summary>
		/// Adds the specified entities.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="entities">The entities.</param>
		void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="entity">The entity.</param>
		void Delete<TEntity>(TEntity entity) where TEntity : class;

		/// <summary>
		/// Deletes the specified entities.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="entities">The entities.</param>
		void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

		/// <summary>
		/// Deletes entities which satify specificatiion
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		void Delete<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <returns></returns>
		IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

		/// <summary>
		/// Gets entities which satifies a specification.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <typeparam name="TOrderBy">The type of the order by.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="pageIndex">Index of the page.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="sortOrder">The sort order.</param>
		/// <returns></returns>
		IEnumerable<TEntity> Get<TEntity, TOrderBy>(ISpecification<TEntity> specification, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;

		/// <summary>
		/// Counts the specified entities.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <returns></returns>
		int Count<TEntity>() where TEntity : class;

		/// <summary>
		/// Counts entities satifying specification.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="specification">The specification.</param>
		/// <returns></returns>
		int Count<TEntity>(ISpecification<TEntity> specification) where TEntity : class;

		/// <summary>
		/// Gets the unit of work.
		/// </summary>
		/// <value>The unit of work.</value>
		IUnitOfWork UnitOfWork { get; }
	}
}
