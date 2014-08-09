using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Judge.DAL.Entities
{
	/// <summary>
	/// Submission class
	/// </summary>
	[Table("Submissions")]
	public class Submission
	{
		public Submission()
		{
			Status = 0;
			CreateTS = DateTime.Now;
			UpdateTS = DateTime.Now;
		}

		public int SubmissionID { get; set; }

		public int UserID { get; set; }

		public int ProblemID { get; set; }

		public string Language { get; set; }

		public int Status { get; set; }

		public string Code { get; set; }

		public DateTime CreateTS { get; set; }

		public DateTime UpdateTS { get; set; }

		public virtual User User { get; set; }

		public virtual Problem Problem { get; set; }
	}
}
