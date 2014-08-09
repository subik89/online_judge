using System.IO;

namespace OnlineJudge.Infrastructure
{
	/// <summary>
	/// IFileSystemService interface
	/// </summary>
	public interface IFileSystemService
	{
		/// <summary>
		/// Directories the exists.
		/// </summary>
		/// <param name="directoryPath">The directory path.</param>
		/// <returns></returns>
		bool DirectoryExists(string directoryPath);

		/// <summary>
		/// Creates the directory.
		/// </summary>
		/// <param name="directoryPath">The directory path.</param>
		/// <returns></returns>
		DirectoryInfo CreateDirectory(string directoryPath);

		/// <summary>
		/// Creates the directory if not exists.
		/// </summary>
		/// <param name="directoryPath">The directory path.</param>
		/// <returns></returns>
		DirectoryInfo CreateDirectoryIfNotExists(string directoryPath);

		/// <summary>
		/// Moves the file.
		/// </summary>
		/// <param name="sourceFileName">Name of the source file.</param>
		/// <param name="destFileName">Name of the dest file.</param>
		void MoveFile(string sourceFileName, string destFileName);

		/// <summary>
		/// Reads from file.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		/// <returns></returns>
		string ReadFromFile(string filePath);

		/// <summary>
		/// Writes to file.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		/// <param name="content">The content.</param>
		void WriteToFile(string filePath, string content);
	}
}
