using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using CompileManagerService.Bootstrappers;
using CompileManagerService.Providers;
using Microsoft.Practices.Unity;
using Online_Judge.BLL.CompilerMangerService;

namespace CompileManagerService
{
	public partial class CompilerManagerService : ServiceBase
	{
		#region Dependencies

		private IUnityContainer _parentContainer;
		private readonly ICompilerManagerSettingsProvider _compilerManagerSettingsProvider;

		#endregion

		#region Fields

		private bool _isWorking;
		private Timer _timer;

		#endregion

		#region Constructor

		public CompilerManagerService()
		{
			InitializeComponent();
			InitializeServiceResources();

			_compilerManagerSettingsProvider = _parentContainer.Resolve<ICompilerManagerSettingsProvider>();
		}

		#endregion

		static void Main(string[] args)
		{
			var compilerManagerService = new CompilerManagerService();

			if (Environment.UserInteractive)
			{
				compilerManagerService.OnStart(args);
				Console.WriteLine("Press any key to stop program");
				Console.Read();
				compilerManagerService.OnStop();
			}
			else
			{
				Run(compilerManagerService);
			}
		}

		#region Base Class Members

		protected override void OnStart(string[] args)
		{
			_timer = new Timer { Interval = _compilerManagerSettingsProvider.TimerInterval };

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
					_parentContainer.Resolve<ICompilerManagerService>().CheckSubmissions();
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

		private void InitializeServiceResources()
		{
			_parentContainer = new UnityContainer();

			Bootstrapper.RegisterApplicationScopeDependencies(_parentContainer);
		}

		#endregion
	}
}