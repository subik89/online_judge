using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using OnlineJudge.Infrastructure;
using OnlineJudge.Infrastructure.Providers;
using Online_Judge.BLL.Entities;

namespace Online_Judge.BLL.Compilers._Impl
{
	public class CSharpCodeCompilerStrategy : ICodeCompilerStrategy
	{
		#region Dependencies

		private readonly IFileSystemService _fileSystemService;
	    private readonly ICompilerManagerSettingsProvider _compilerManagerSettingsProvider;

		#endregion

		#region Constructor

		public CSharpCodeCompilerStrategy(IFileSystemService fileSystemService, ICompilerManagerSettingsProvider compilerManagerSettingsProvider)
		{
		    _fileSystemService = fileSystemService;
		    _compilerManagerSettingsProvider = compilerManagerSettingsProvider;
		}

	    #endregion

		#region ICSharpCompiler Members

		public CodeCompilerResult Compile(string sourceCode)
		{
			var codeProvider = CodeDomProvider.CreateProvider("CSharp");

		    string fileName = $"{Guid.NewGuid()}.exe";

			var parameters = new CompilerParameters {GenerateExecutable = true, OutputAssembly = fileName};

			var results = codeProvider.CompileAssemblyFromSource(parameters, sourceCode);

		    var destinationPath = Path.Combine(_compilerManagerSettingsProvider.DestinationPath, fileName);

            _fileSystemService.MoveFile(results.CompiledAssembly.Location, destinationPath);

			results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));

		    return new CodeCompilerResult {CompileStatus = !results.Errors.HasErrors, DestinationFilePath = destinationPath};
		}

		#endregion
	}
}