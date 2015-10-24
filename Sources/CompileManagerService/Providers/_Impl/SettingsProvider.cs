using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using OnlineJudge.Infrastructure.Providers;

namespace CompileManagerService.Providers._Impl
{
	public class SettingsProvider : ICompilerManagerSettingsProvider
	{
		#region ICompilerManagerSettingsProvider Members

		public int TimerInterval => GetInt();

	    public string DestinationPath => GetString();

	    #endregion

		#region Private Methods

		private string GetString([CallerMemberName] string key = null)
		{
			return ConfigurationManager.AppSettings[key];
		}

		private int GetInt([CallerMemberName] string key = null)
		{
			return Int32.Parse(GetString(key));
		}

		#endregion
	}
}
