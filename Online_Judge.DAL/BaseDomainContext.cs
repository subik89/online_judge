using System.Data.Entity;

namespace Online_Judge.DAL
{
	/// <summary>
	/// BaseDomainContext class
	/// </summary>
	public abstract class BaseDomainContext : DbContext
	{
		protected BaseDomainContext(string connectionString)
		{
			// ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
			// As it is installed in the GAC, Copy Local does not work. It is required for probing.
			// Fixed "Provider not loaded" error
			var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

			Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineJudgeDBContext, Migrations.Configuration>(connectionString));
		}
	}
}
