using System.ServiceProcess;
using System.Timers;
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

		#region Fields

		private bool _isWorking;
		private Timer _timer;

		#endregion

		#region Constructor

		public CompilerManagerService()
		{
			InitializeComponent();
			_compilerManagerService =
				new Online_Judge.BLL.CompilerMangerService.Impl.CompilerManagerService(
					new GenericRepository(new OnlineJudgeDBContext()), new CSharpCompiler(new FileSystemService()),
					new SubmissionValidator(), new FileSystemService());
		}

		#endregion

		#region Base Class Members

		protected override void OnStart(string[] args)
		{
			_timer = new Timer {Interval = 10000};

			_timer.Elapsed += OnTimerElapsed;
			_timer.Start();
		}

		#endregion

		#region Private Methods

		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			if (!_isWorking)
			{
				_isWorking = true;

				_compilerManagerService.CheckSubmissions();

				_isWorking = false;
			}
		}

		#endregion
	}
}