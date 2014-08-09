namespace Online_Judge.BLL.CompilerMangerService
{
	/// <summary>
	/// ISubmissionValidator interface
	/// </summary>
	public interface ISubmissionValidator
	{
		bool Validate(string actualOutputResult, string expectedOutputResult);
	}
}
