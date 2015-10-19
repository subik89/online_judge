using System;
using System.Diagnostics;
using System.Text;
using OnlineJudge.Infrastructure;
using Online_Judge.Core.Extensions;
using Online_Judge.DAL;
using Online_Judge.DAL.Entities;
using Online_Judge.DAL.Specification;
using System.Linq;

namespace Online_Judge.BLL.CompilerMangerService._Impl
{
	public class CompilerManagerService : ICompilerManagerService
	{
		#region Dependencies

		private readonly IRepository _genericRepository;

		//TODO: Remove ICSharpCompiler from dependencies
		private readonly ICodeCompiler _csharpCompiler;

		private readonly ISubmissionValidator _submissionValidator;
		private readonly IFileSystemService _fileSystemService;

		#endregion

		#region Constructor

		public CompilerManagerService(IRepository genericRepository, ICodeCompiler csharpCompiler, ISubmissionValidator submissionValidator, IFileSystemService fileSystemService)
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
				var destinationPath = string.Format("C:/Data/OnlineJudge/results/{0}", submission.SubmissionID.ToString());

				if (submission.Language.Equals("C#"))
				{
					const string executionFilePath = @"C:\Data\OnlineJudge\compile.exe";
					var status = _csharpCompiler.Compile(submission.Code, executionFilePath, destinationPath);

					if (!status)
					{
						submission.Status = SubmissionStatus.CompilationError.GetString();
						submission.IsChecked = true;
						submission.UpdateTS = DateTime.Now;

						continue;
					}

					var destinationResultPath = string.Format("{0}/{1}", destinationPath, "result.txt");

					RunProgram(executionFilePath, destinationResultPath);

					var destinationResult = _fileSystemService.ReadFromFile(destinationResultPath);

					var test = _genericRepository.SingleOrDefault(new Specification<Test>(x => x.ProblemID == submission.ProblemID));
					var testContent = _fileSystemService.ReadFromFile(string.Format("C:/Data/OnlineJudge/{0}.txt", test.Name));

					submission.Status = _submissionValidator.Validate(destinationResult, testContent).GetString();
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