namespace Online_Judge.BLL.CompilerMangerService.Impl
{
	/// <summary>
	/// SubmissionValidator class
	/// </summary>
	public class SubmissionValidator : ISubmissionValidator
	{
		public bool Validate(string actualOutputResult, string expectedOutputResult)
		{
			return actualOutputResult.Trim().Equals(expectedOutputResult.Trim());
		}
	}
}
