using System;
using System.Diagnostics;
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

		private ICompilerManagerService _compilerManagerService;

		#endregion

		#region Fields

		private bool _isWorking;
		private Timer _timer;

		#endregion

		#region Constructor

		public CompilerManagerService()
		{
			InitializeComponent();
		}

		#endregion

		#region Base Class Members

		protected override void OnStart(string[] args)
		{
			_timer = new Timer { Interval = 10000 };

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

				try
				{
					//TODO: Moved to constructor and create context per call
					_compilerManagerService = new Online_Judge.BLL.CompilerMangerService.Impl.CompilerManagerService(
					new GenericRepository(new OnlineJudgeDBContext()), new CSharpCompiler(new FileSystemService()),
					new SubmissionValidator(), new FileSystemService());

					_compilerManagerService.CheckSubmissions();
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex.Message);
				}
				finally
				{
					_isWorking = false;
				}
			}
		}

		#endregion
	}
}