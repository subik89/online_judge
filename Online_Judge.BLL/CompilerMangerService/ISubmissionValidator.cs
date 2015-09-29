using Online_Judge.DAL;

namespace Online_Judge.BLL.CompilerMangerService
{
	public interface ISubmissionValidator
	{
		SubmissionStatus Validate(string actualOutputResult, string expectedOutputResult);
	}
}
