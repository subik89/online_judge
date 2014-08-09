using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using OnlineJudge.Infrastructure;
using Online_Judge.BLL.Compilers;
using Online_Judge.DAL;
using Online_Judge.DAL.Entities;
using Online_Judge.DAL.Specification;
using System.Linq;

namespace Online_Judge.BLL.CompilerMangerService.Impl
{
	/// <summary>
	/// CompilerManagerService class
	/// </summary>
	public class CompilerManagerService : ICompilerManagerService
	{
		#region Dependencies

		private readonly IRepository _genericRepository;
		private readonly ICSharpCompiler _csharpCompiler;
		private readonly ISubmissionValidator _submissionValidator;
		private readonly IFileSystemService _fileSystemService;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="CompilerManagerService" /> class.
		/// </summary>
		/// <param name="genericRepository">The generic repository.</param>
		/// <param name="csharpCompiler">The csharp compiler.</param>
		/// <param name="submissionValidator">The submission validator.</param>
		/// <param name="fileSystemService">The file system service.</param>
		public CompilerManagerService(IRepository genericRepository, ICSharpCompiler csharpCompiler, ISubmissionValidator submissionValidator, IFileSystemService fileSystemService)
		{
			_genericRepository = genericRepository;
			_csharpCompiler = csharpCompiler;
			_submissionValidator = submissionValidator;
			_fileSystemService = fileSystemService;
		}

		#endregion

		#region ICompilerManagerService Members

		public void CheckSubmissions()
		{
			var submissionToCheck = _genericRepository.Find(new Specification<Submission>(x => x.IsChecked == false)).ToList();

			if (!submissionToCheck.Any())
			{
				return;
			}

			foreach (var submission in submissionToCheck)
			{
				if (submission.Language.Equals("C#"))
				{
					var destinationPath = string.Format("C:/temp/{0}", submission.SubmissionID.ToString());
					var status = _csharpCompiler.Compile(submission.Code, "compile.exe", destinationPath);

					if (!status)
					{
						submission.IsChecked = true;
						submission.UpdateTS = DateTime.Now;
						continue;
					}

					var destinationResultPath = string.Format("{0}/{1}", destinationPath, "result.txt");

					RunProgram(string.Format("{0}/{1}", destinationPath, "compile.exe"), destinationResultPath);

					var destinationResult = _fileSystemService.ReadFromFile(destinationResultPath);

					if (_submissionValidator.Validate(destinationResult, "3"))
					{
						submission.Status = 1;
					}
					else
					{
						submission.Status = 2;
					}

					submission.IsChecked = true;
					submission.UpdateTS = DateTime.Now;
				}
			}

			_genericRepository.UnitOfWork.SaveChanges();
		}

		public void RunProgram(string path, string resultFilePath)
		{
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = path,
					Arguments = "command line arguments to your executable",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};

			proc.Start();

			var stringBuilder = new StringBuilder();
			while (!proc.StandardOutput.EndOfStream)
			{
				string line = proc.StandardOutput.ReadLine();
				stringBuilder.Append(line);
			}

			_fileSystemService.WriteToFile(resultFilePath, stringBuilder.ToString());
		}

		#endregion
	}
}