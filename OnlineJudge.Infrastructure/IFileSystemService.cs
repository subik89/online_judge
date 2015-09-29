using System.IO;

namespace OnlineJudge.Infrastructure
{
	public interface IFileSystemService
	{
		bool DirectoryExists(string directoryPath);
		DirectoryInfo CreateDirectory(string directoryPath);
		DirectoryInfo CreateDirectoryIfNotExists(string directoryPath);
		void MoveFile(string sourceFileName, string destFileName);
		string ReadFromFile(string filePath);
		void WriteToFile(string filePath, string content);
	}
}
