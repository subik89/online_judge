using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Judge.DAL.Entities
{
	/// <summary>
	/// Test class
	/// </summary>
	[Table("Tests")]
	public class Test
	{
		public int TestID { get; set; }

		public int ProblemID { get; set; }

		public string Name { get; set; }

		public TimeSpan TimeLimit { get; set; }

		public DateTime CreateTS { get; set; }

		public DateTime UpdateTS { get; set; }
	}
}
