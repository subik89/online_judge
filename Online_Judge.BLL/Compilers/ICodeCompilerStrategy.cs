namespace Online_Judge.BLL.Compilers
{
	public interface ICodeCompilerStrategy
	{
		bool Compile(string sourceCode, string fileName, string destinationPath);
	}
}
