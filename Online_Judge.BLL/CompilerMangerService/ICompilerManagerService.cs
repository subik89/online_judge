namespace Online_Judge.BLL.CompilerMangerService
{
	/// <summary>
	/// ICompilerManagerService class
	/// </summary>
	public interface ICompilerManagerService
	{
		void CheckSubmissions();

		void RunProgram(string path, string resultFilePath);
	}
}
