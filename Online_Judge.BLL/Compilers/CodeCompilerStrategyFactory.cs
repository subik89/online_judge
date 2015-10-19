using System;
using System.Collections.Generic;
using OnlineJudge.Infrastructure;
using Online_Judge.BLL.Compilers._Impl;
using Online_Judge.DAL.Enum;

namespace Online_Judge.BLL.Compilers
{
	public class CodeCompilerStrategyFactory : ICodeCompilerStrategyFactory
	{
		#region Dependencies

		private readonly IDictionary<AvailableProgrammingLanguage, Func<ICodeCompilerStrategy>> _codeCompilerStrategies = new Dictionary<AvailableProgrammingLanguage, Func<ICodeCompilerStrategy>>();

		private readonly IFileSystemService _fileSystemService;

		#endregion

		#region Constructor

		public CodeCompilerStrategyFactory(IFileSystemService fileSystemService)
		{
			_fileSystemService = fileSystemService;

			_codeCompilerStrategies.Add(AvailableProgrammingLanguage.CSHARP, () => new CSharpCodeCompilerStrategy(_fileSystemService));
			_codeCompilerStrategies.Add(AvailableProgrammingLanguage.JAVA, () => new JavaCodeCompilerStrategy());
			_codeCompilerStrategies.Add(AvailableProgrammingLanguage.CPlus, () => new CPlusCodeCompilerStrategy());
		}

		#endregion

		#region ICodeCompilerStrategyFactory Members

		public ICodeCompilerStrategy GetCodeCompilerStrategy(AvailableProgrammingLanguage language)
		{
			return _codeCompilerStrategies[language].Invoke();
		}

		#endregion
	}
}