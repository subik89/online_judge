using Online_Judge.BLL.Entities;
using Online_Judge.DAL.Enum;

namespace Online_Judge.BLL.Compilers.Commands
{
	public interface ICodeCompilerCommand
	{
	    CodeCompilerResult Compile(string sourceCode, AvailableProgrammingLanguage language);
	}
}
