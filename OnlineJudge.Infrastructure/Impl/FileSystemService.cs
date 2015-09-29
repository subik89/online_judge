using System.IO;

namespace OnlineJudge.Infrastructure.Impl
{
	public class FileSystemService : IFileSystemService
	{
		#region IFileSystemService Members

		public bool DirectoryExists(string directoryPath)
		{
			return Directory.Exists(directoryPath);
		}

		public DirectoryInfo CreateDirectory(string directoryPath)
		{
			return Directory.CreateDirectory(directoryPath);
		}

		public DirectoryInfo CreateDirectoryIfNotExists(string directoryPath)
		{
			var directoryInfo = new DirectoryInfo(directoryPath);

			if (!DirectoryExists(directoryPath))
			{
				CreateDirectory(directoryPath);
			}

			return directoryInfo;
		}

		public void MoveFile(string sourceFileName, string destFileName)
		{
			CreateDirectoryIfNotExists(Path.GetDirectoryName(destFileName));

			if (File.Exists(destFileName))
			{
				File.Delete(destFileName);
			}

			File.Move(sourceFileName, destFileName);
		}

		public string ReadFromFile(string filePath)
		{
			return File.ReadAllText(filePath);
		}

		public void WriteToFile(string filePath, string content)
		{
			CreateDirectoryIfNotExists(Path.GetDirectoryName(filePath));

			File.WriteAllText(filePath, content);
		}

		#endregion

		#region Public Methods

		public void CreateFileIfNotExists(string filePath)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
			}
		}

		#endregion
	}
}