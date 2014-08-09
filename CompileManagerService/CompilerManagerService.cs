using System.ServiceProcess;
using OnlineJudge.Infrastructure.Impl;
using Online_Judge.BLL.CompilerMangerService;
using Online_Judge.BLL.CompilerMangerService.Impl;
using Online_Judge.BLL.Compilers.Impl;
using Online_Judge.DAL;

namespace CompileManagerService
{
	public partial class CompilerManagerService : ServiceBase
	{
		#region Dependencies

		private readonly ICompilerManagerService _compilerManagerService;

		#endregion

		public CompilerManagerService()
		{
			InitializeComponent();
			_compilerManagerService = new Online_Judge.BLL.CompilerMangerService.Impl.CompilerManagerService(new GenericRepository(new OnlineJudgeDBContext()), new CSharpCompiler(new FileSystemService()), new SubmissionValidator(), new FileSystemService());
		}

		protected override void OnStart(string[] args)
		{
			_compilerManagerService.CheckSubmissions();
		}

		protected override void OnStop()
		{
		}
	}
}
