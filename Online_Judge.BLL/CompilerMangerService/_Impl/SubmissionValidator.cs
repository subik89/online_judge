using Online_Judge.DAL;

namespace Online_Judge.BLL.CompilerMangerService._Impl
{
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
