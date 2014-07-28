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

			BuilderSetup.SetCreatePersistenceMethod<Problem>(AddEntity);
			BuilderSetup.SetCreatePersistenceMethod<IList<Problem>>(AddList);
		}

		protected void CreateContext()
		{
			if (ContextDisposed)
			{
				Context = new OnlineJudgeDBContext();
				ContextDisposed = false;
			}
		}

		protected void DisposeRAPContext()
		{
			if (!ContextDisposed)
			{
				Context.Dispose();
				ContextDisposed = true;
			}
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
