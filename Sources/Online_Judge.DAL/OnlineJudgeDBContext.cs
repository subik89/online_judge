using System.Data.Entity;
using Online_Judge.DAL.Entities;

namespace Online_Judge.DAL
{
	/// <summary>
	/// OnlineJudgeDBContext class
	/// </summary>
	public class OnlineJudgeDBContext : DbContext
	{
		#region Properties

		public DbSet<User> Users { get; set; }
		public DbSet<Problem> Problems { get; set; }
		public DbSet<Submission> Submissions { get; set; }
		public DbSet<Test> Tests { get; set; }

		#endregion

		#region Constructor

		public OnlineJudgeDBContext()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineJudgeDBContext, Migrations.Configuration>());
		}

		#endregion
	}
}