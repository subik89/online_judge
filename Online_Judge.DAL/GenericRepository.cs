using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Online_Judge.DAL.Specification;
using Online_Judge.DAL._Impl;

namespace Online_Judge.DAL
{
	/// <summary>
	/// GenericRepository class
	/// </summary>
	public class GenericRepository : IRepository
	{
		#region Dependencies

		private readonly OnlineJudgeDBContext _context;

		#endregion

		#region Fields

		private IUnitOfWork _unitOfWork;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <exception cref="System.ArgumentNullException">context</exception>
		public GenericRepository(OnlineJudgeDBContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			_context = context;
		}

		#endregion

		#region IRepository Members

		public IUnitOfWork UnitOfWork
		{
			get { return _unitOfWork ?? (_unitOfWork = new UnitOfWork(_context)); }
		}

		public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
		{
			var entityName = GetEntityName<TEntity>();
			return ((IObjectContextAdapter) _context).ObjectContext.CreateQuery<TEntity>(entityName);
		}

		public IQueryable<TEntity> GetQuery<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>());
		}

		public IEnumerable<TEntity> Get<TEntity, TOrderBy>(Specification<TEntity> specification,
		                                                   Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex,
		                                                   int pageSize,
		                                                   SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
		{
			if (sortOrder == SortOrder.Ascending)
			{
				return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>())
									.OrderBy(orderBy)
									.Skip((pageIndex - 1)*pageSize)
									.Take(pageSize)
									.AsEnumerable();
			}

			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>())
								.OrderByDescending(orderBy)
								.Skip((pageIndex - 1)*pageSize)
								.Take(pageSize)
								.AsEnumerable();
		}

		public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
		{
			return GetQuery<TEntity>().AsEnumerable();
		}

		public TEntity Single<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).Single();
		}

		public TEntity SingleOrDefault<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).SingleOrDefault();
		}

		public TEntity First<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).First();
		}

		public TEntity FirstOrDefault<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).FirstOrDefault();
		}

		public IEnumerable<TEntity> Find<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).AsEnumerable();
		}

		public void Add<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			_context.Set<TEntity>().Add(entity);
		}

		public void Add<TEntity>(List<TEntity> entities) where TEntity : class
		{
			if (entities == null || !entities.Any())
			{
				throw new ArgumentNullException("entities");
			}

			_context.Set<TEntity>().AddRange(entities);
		}

		public void Delete<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			_context.Set<TEntity>().Remove(entity);
		}

		public void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
		{
			if (entities == null || !entities.Any())
			{
				throw new ArgumentNullException("entities");
			}

			_context.Set<TEntity>().RemoveRange(entities);
		}

		public void Delete<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			IEnumerable<TEntity> records = Find(specification);
			_context.Set<TEntity>().RemoveRange(records);
		}

		public int Count<TEntity>() where TEntity : class
		{
			return GetQuery<TEntity>().Count();
		}

		public int Count<TEntity>(Specification<TEntity> specification) where TEntity : class
		{
			return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).Count();
		}

		#endregion

		#region Private Methods

		private string GetEntityName<TEntity>() where TEntity : class
		{
			string entitySetName = ((IObjectContextAdapter) _context).ObjectContext
			                                                         .MetadataWorkspace
			                                                         .GetEntityContainer(
				                                                         ((IObjectContextAdapter) _context).ObjectContext
				                                                                                           .DefaultContainerName,
				                                                         DataSpace.CSpace)
			                                                         .BaseEntitySets.First(
				                                                         bes => bes.ElementType.Name == typeof (TEntity).Name).Name;

			return string.Format("{0}.{1}", ((IObjectContextAdapter) _context).ObjectContext.DefaultContainerName, entitySetName);
		}

		#endregion
	}
}