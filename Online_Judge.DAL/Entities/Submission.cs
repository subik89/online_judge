using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Online_Judge.Core.Extensions;

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
			CreateTS = DateTime.Now;
			UpdateTS = DateTime.Now;
		}

		public int SubmissionID { get; set; }

		public int UserID { get; set; }

		public int ProblemID { get; set; }

		[StringLength(20)]
		public string Language { get; set; }

		[StringLength(100)]
		public string Status { get; set; }

		public string Code { get; set; }

		public bool IsChecked { get; set; }

		public DateTime CreateTS { get; set; }

		public DateTime UpdateTS { get; set; }

		public virtual User User { get; set; }

		public virtual Problem Problem { get; set; }
	}
}
