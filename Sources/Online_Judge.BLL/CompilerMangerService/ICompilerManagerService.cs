namespace Online_Judge.BLL.CompilerMangerService
{
	public interface ICompilerManagerService
	{
		void CheckSubmissions();
		void RunProgram(string path, string resultFilePath);
	}
}
