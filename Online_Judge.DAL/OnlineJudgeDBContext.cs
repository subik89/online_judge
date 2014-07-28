using System.Data.Entity;
using Online_Judge.DAL.Entities;

namespace Online_Judge.DAL
{
	/// <summary>
	/// OnlineJudgeDBContext class
	/// </summary>
	public class OnlineJudgeDBContext : BaseDomainContext
	{
		public OnlineJudgeDBContext() 
			: base("OnlineJudgeConnection")
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Problem> Problems { get; set; } 

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Make an ID property as PrimaryKey eg. UserID
			modelBuilder
				.Properties()
				.Where(p => p.Name == p.DeclaringType.Name + "ID")
				.Configure(p => p.IsKey());

			base.OnModelCreating(modelBuilder);
		}
	}
}
