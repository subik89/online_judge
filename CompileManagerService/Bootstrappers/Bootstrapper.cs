using CompileManagerService.Providers;
using CompileManagerService.Providers._Impl;
using Microsoft.Practices.Unity;
using OnlineJudge.Infrastructure;
using OnlineJudge.Infrastructure.Impl;
using Online_Judge.BLL.CompilerMangerService;
using Online_Judge.BLL.CompilerMangerService.Impl;
using Online_Judge.BLL.Compilers;
using Online_Judge.BLL.Compilers.Impl;
using Online_Judge.DAL;

namespace CompileManagerService.Bootstrappers
{
	class Bootstrapper
	{
		public static void RegisterApplicationScopeDependencies(IUnityContainer container)
		{
			container.RegisterType<OnlineJudgeDBContext>(new TransientLifetimeManager());
			container.RegisterType<IRepository, GenericRepository>();

			container.RegisterType<ICompilerManagerService, Online_Judge.BLL.CompilerMangerService.Impl.CompilerManagerService>();
			container.RegisterType<ICompilerManagerSettingsProvider, SettingsProvider>();
			container.RegisterType<ICSharpCompiler, CSharpCompiler>();
			container.RegisterType<ISubmissionValidator, SubmissionValidator>();
			container.RegisterType<IFileSystemService, FileSystemService>();
		}
	}
}
