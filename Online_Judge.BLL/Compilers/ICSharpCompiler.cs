namespace Online_Judge.BLL.Compilers
{
	/// <summary>
	/// ICSharpCompiler class
	/// </summary>
	public interface ICSharpCompiler
	{
		bool Compile(string sourceCode, string destinationPath);
	}
}
