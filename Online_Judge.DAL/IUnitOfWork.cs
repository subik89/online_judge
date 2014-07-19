using System;
using System.Data;

namespace Online_Judge.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		bool IsInTransaction { get; }

		void SaveChanges();

		void BeginTransaction();

		void BeginTransaction(IsolationLevel isolationLevel);

		void RollBackTransaction();

		void CommitTransaction();
	}
}
