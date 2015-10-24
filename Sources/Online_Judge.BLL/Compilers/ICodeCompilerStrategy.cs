using Online_Judge.BLL.Entities;

namespace Online_Judge.BLL.Compilers
{
	public interface ICodeCompilerStrategy
	{
		CodeCompilerResult Compile(string sourceCode);
	}

}