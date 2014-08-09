using System.IO;

namespace OnlineJudge.Infrastructure.Impl
{
	/// <summary>
	/// FileSystemService class
	/// </summary>
	public class FileSystemService : IFileSystemService
	{
		/// <summary>
		/// Determines whether the given path refers to an existing directory on disk.
		/// </summary>
		/// <param name="directoryPath"> The directory path. </param>
		/// <returns> </returns>
		public bool DirectoryExists(string directoryPath)
		{
			return Directory.Exists(directoryPath);
		}

		/// <summary>
		/// Creates all directories and subdirectories as specified by path.
		/// </summary>
		/// <param name="directoryPath"> The directory path. </param>
		/// <returns> </returns>
		public DirectoryInfo CreateDirectory(string directoryPath)
		{
			return Directory.CreateDirectory(directoryPath);
		}

		/// <summary>
		/// Creates all directories and subdirectories as specified by path.
		/// </summary>
		/// <param name="directoryPath"> The directory path. </param>
		/// <returns> </returns>
		public DirectoryInfo CreateDirectoryIfNotExists(string directoryPath)
		{
			var directoryInfo = new DirectoryInfo(directoryPath);

			if (!DirectoryExists(directoryPath))
			{
				CreateDirectory(directoryPath);
			}

			return directoryInfo;
		}

		public void CreateFileIfNotExists(string filePath)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
			}
		}

		/// <summary>
		/// Moves the file.
		/// </summary>
		/// <param name="sourceFileName">Name of the source file.</param>
		/// <param name="destFileName">Name of the dest file.</param>
		public void MoveFile(string sourceFileName, string destFileName)
		{
			CreateDirectoryIfNotExists(Path.GetDirectoryName(destFileName));

			if (File.Exists(destFileName))
			{
				File.Delete(destFileName);
			}

			File.Move(sourceFileName, destFileName);
		}

		/// <summary>
		/// Reads specified file
		/// </summary>
		/// <param name="filePath"> The file path. </param>
		/// <returns> </returns>
		public string ReadFromFile(string filePath)
		{
			return File.ReadAllText(filePath);
		}

		/// <summary>
		/// Writes content to the specified file.
		/// </summary>
		/// <param name="filePath"> The file path. </param>
		/// <param name="content"> The content. </param>
		public void WriteToFile(string filePath, string content)
		{
			File.WriteAllText(filePath, content);
		}
	}
}
