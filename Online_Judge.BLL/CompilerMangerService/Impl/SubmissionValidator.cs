using Online_Judge.DAL;

namespace Online_Judge.BLL.CompilerMangerService.Impl
{
	/// <summary>
	/// SubmissionValidator class
	/// </summary>
	public class SubmissionValidator : ISubmissionValidator
	{
		public SubmissionStatus Validate(string actualOutputResult, string expectedOutputResult)
		{
			if(actualOutputResult.Trim().Equals(expectedOutputResult.Trim()))
			{
				return SubmissionStatus.Success;
			}

			return SubmissionStatus.IncorrectAnswer;
		}
	}
}
