using Online_Judge.Core.Attributes;

namespace Online_Judge.DAL
{
	/// <summary>
	/// SubmissionStatus enum
	/// </summary>
	public enum SubmissionStatus
	{
		[StringValue("SUBMITTED")]
		Submitted,

		[StringValue("SUCCESS")]
		Success,

		[StringValue("COMPILATION_ERROR")]
		CompilationError,

		[StringValue("INCORRECT_ANSWER")]
		IncorrectAnswer,

		[StringValue("RUNTIME_ERROR")]
		RuntimeError,

		[StringValue("TIMEOUT")]
		Timeout
	}
}
