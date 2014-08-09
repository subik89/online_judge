namespace Online_Judge.BLL.Compilers
{
	/// <summary>
	/// ICSharpCompiler class
	/// </summary>
	public interface ICSharpCompiler
	{
		/// <summary>
		/// Compiles the specified source code.
		/// </summary>
		/// <param name="sourceCode">The source code.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="destinationPath">The destination path.</param>
		/// <returns></returns>
		bool Compile(string sourceCode, string fileName, string destinationPath);
	}
}
