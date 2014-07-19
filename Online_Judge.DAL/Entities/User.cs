using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Judge.DAL.Entities
{
	/// <summary>
	/// User class
	/// </summary>
	[Table("Users")]
	public class User
	{
		public int UserID { get; set; }

		[Required]
		[Column("Email", TypeName = "nvarchar")]
		[MaxLength(300)]
		public string Email { get; set; }

		[Required]
		[Column("FirstName", TypeName = "nvarchar")]
		[MaxLength(100)]
		public string FirstName { get; set; }

		[Required]
		[Column("LastName", TypeName = "nvarchar")]
		[MaxLength(100)]
		public string LastName { get; set; }

		[Required]
		[Column("Password", TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Password { get; set; }

		[Required]
		[Column("CreateTS", TypeName = "datetime")]
		public DateTime CreateTS { get; set; }

		[Required]
		[Column("UpdateTS", TypeName = "datetime")]
		public DateTime UpdateTS { get; set; }
	}
}
