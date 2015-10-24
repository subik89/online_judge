using System.Collections.Generic;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Online_Judge.DAL.Entities;

namespace Online_Judge.DAL.Tests
{
	/// <summary>
	/// TestsBase class
	/// </summary>
	[TestClass]
	public class TestsBase
	{
		protected OnlineJudgeDBContext Context { get; set; }
		protected bool ContextDisposed = true;

		[TestInitialize]
		public void StartTest()
		{
			CreateContext();
			CleanupDatabase();

			BuilderSetup.SetCreatePersistenceMethod<Problem>(AddEntity);
			BuilderSetup.SetCreatePersistenceMethod<IList<Problem>>(AddList);
			BuilderSetup.SetCreatePersistenceMethod<User>(AddEntity);
			BuilderSetup.SetCreatePersistenceMethod<IList<User>>(AddList);
		}

		protected void CreateContext()
		{
			if (ContextDisposed)
			{
				Context = new OnlineJudgeDBContext();
				ContextDisposed = false;
			}
		}

		protected void DisposeContext()
		{
			if (!ContextDisposed)
			{
				Context.Dispose();
				ContextDisposed = true;
			}
		}

		protected void CleanupDatabase()
		{
			Context.Database.ExecuteSqlCommand(@"Delete from Problems");
			Context.Database.ExecuteSqlCommand(@"Delete from Users");
		}

		private void AddEntity<TEntity>(TEntity entity) where TEntity : class
		{
			Context.Set<TEntity>().Add(entity);
		}

		private void AddList<TEntity>(IList<TEntity> entities) where TEntity : class
		{
			Context.Set<TEntity>().AddRange(entities);
		}
	}
}
