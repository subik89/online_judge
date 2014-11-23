using Online_Judge.DAL;

namespace Online_Judge.BLL.CompilerMangerService
{
	/// <summary>
	/// ISubmissionValidator interface
	/// </summary>
	public interface ISubmissionValidator
	{
		SubmissionStatus Validate(string actualOutputResult, string expectedOutputResult);
	}
}
