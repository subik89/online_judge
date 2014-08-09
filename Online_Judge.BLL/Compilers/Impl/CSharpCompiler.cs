using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using OnlineJudge.Infrastructure;

namespace Online_Judge.BLL.Compilers.Impl
{
	/// <summary>
	/// CSharpCompiler class
	/// </summary>
	public class CSharpCompiler : ICSharpCompiler
	{
		#region Dependencies

		private readonly IFileSystemService _fileSystemService;

		#endregion

		#region Constructor

		public CSharpCompiler(IFileSystemService fileSystemService)
		{
			_fileSystemService = fileSystemService;
		}

		#endregion

		#region ICSharpCompiler Members

		public bool Compile(string sourceCode, string fileName, string destinationPath)
		{
			CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

			var parameters = new CompilerParameters {GenerateExecutable = true, OutputAssembly = fileName};

			CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sourceCode);

			_fileSystemService.MoveFile(results.CompiledAssembly.Location, Path.Combine(destinationPath, fileName));

			results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));

			if (results.Errors.HasErrors)
			{
				return false;
			}

			return true;
		}

		#endregion
	}
}