using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Judge.DAL.Entities
{
	/// <summary>
	/// Problem class
	/// </summary>
	[Table("Problems")]
	public class Problem
	{
		public Problem()
		{
			CreateTS = DateTime.Now;
			UpdateTS = DateTime.Now;
		}

		[Key]
		public int ProblemID { get; set; }

		[Required]
		[Column("Name", TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[Column("Title", TypeName = "nvarchar")]
		[MaxLength(300)]
		public string Title { get; set; }

		[Required]
		[Column("Content", TypeName = "nvarchar")]
		public string Content { get; set; }

		[Required]
		public DateTime CreateTS { get; set; }

		[Required]
		public DateTime UpdateTS { get; set; }

		public ICollection<Test> Tests { get; set; } 
	}
}
