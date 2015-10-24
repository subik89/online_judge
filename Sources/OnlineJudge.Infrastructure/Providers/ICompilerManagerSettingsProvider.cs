namespace OnlineJudge.Infrastructure.Providers
{
	public interface ICompilerManagerSettingsProvider
	{
		int TimerInterval { get; }

        string DestinationPath { get; }
	}
}
