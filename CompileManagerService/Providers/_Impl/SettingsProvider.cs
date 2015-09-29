using System;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace CompileManagerService.Providers._Impl
{
	public class SettingsProvider : ICompilerManagerSettingsProvider
	{
		#region ICompilerManagerSettingsProvider Members

		public int TimerInterval
		{
			get { return GetInt(); }
		}

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
