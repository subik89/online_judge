using Online_Judge.DAL.Enum;

namespace Online_Judge.BLL.Compilers
{
	public interface ICodeCompilerStrategyFactory
	{
		ICodeCompilerStrategy GetCodeCompilerStrategy(AvailableProgrammingLanguage language);
	}
}
