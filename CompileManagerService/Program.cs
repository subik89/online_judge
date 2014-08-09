using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading;

namespace CompileManagerService
{
	internal static class Program
	{
		private static readonly Regex ExecutionModeRegex = new Regex("[-/]console",
																	 RegexOptions.Compiled
																	 | RegexOptions.CultureInvariant
																	 | RegexOptions.IgnoreCase);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		private static void Main(string[] args)
		{
			var service = new CompilerManagerService();

			var servicesToRun = new ServiceBase[] 
				{ 
					service
				};

			var isConsoleMode = (args ?? Enumerable.Empty<string>()).Any(x => ExecutionModeRegex.IsMatch(x));

			if (isConsoleMode)
			{
				typeof (CompilerManagerService)
					.GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic)
					.Invoke(service, new object[] {args});

				Thread.Sleep(Timeout.Infinite);
			}
			else
			{

				ServiceBase.Run(servicesToRun);
			}
		}
	}
}
