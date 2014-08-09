using System;
using System.CodeDom.Compiler;
using System.Linq;

namespace Online_Judge.BLL.Compilers.Impl
{
	/// <summary>
	/// CSharpCompiler class
	/// </summary>
	public class CSharpCompiler : ICSharpCompiler
	{
		public bool Compile(string sourceCode, string destinationPath)
		{
			CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

			var parameters = new CompilerParameters {GenerateExecutable = true, OutputAssembly = destinationPath};

			CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sourceCode);

			results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));

			if (results.Errors.HasErrors)
			{
				return false;
			}

			return true;
		}
	}
}
