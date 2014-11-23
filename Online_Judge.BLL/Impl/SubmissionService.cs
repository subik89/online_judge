using System;
using System.Collections.Generic;
using Online_Judge.DAL;
using Online_Judge.DAL.Entities;
using Online_Judge.DAL.Specification;
using Online_Judge.Core.Extensions;

namespace Online_Judge.BLL.Impl
{
	/// <summary>
	/// SubmissionService class
	/// </summary>
	public class SubmissionService : ISubmissionService
	{
		#region Dependencies

		private readonly IRepository _submissionRepository;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SubmissionService"/> class.
		/// </summary>
		/// <param name="submissionRepository">The submission repository.</param>
		public SubmissionService(IRepository submissionRepository)
		{
			_submissionRepository = submissionRepository;
		}

		#endregion

		public IEnumerable<Submission> GetSubmissions(int userID)
		{
			return _submissionRepository.Find(new Specification<Submission>(x => x.UserID == userID));
		}

		public Submission GetSubmission(int submissionID)
		{
			return _submissionRepository.SingleOrDefault(new Specification<Submission>(x => x.SubmissionID == submissionID));
		}

		public void AddSubmission(Submission submission)
		{
			_submissionRepository.Add(submission);

			_submissionRepository.UnitOfWork.SaveChanges();
		}

		public void UpdateSubmission(Submission submission)
		{
			var existingSubmission = _submissionRepository.SingleOrDefault(new Specification<Submission>(x => x.SubmissionID == submission.SubmissionID));

			if (existingSubmission == null)
			{
				throw new InvalidOperationException(string.Format("Submission of id {0} does not exist", submission.SubmissionID));
			}

			existingSubmission.UserID = submission.UserID;
			existingSubmission.ProblemID = submission.ProblemID;
			existingSubmission.Code = submission.Code;
			existingSubmission.Language = submission.Language;
			existingSubmission.Status = SubmissionStatus.Submitted.GetString();
			existingSubmission.UpdateTS = DateTime.Now;

			_submissionRepository.UnitOfWork.SaveChanges();
		}

		public void DeleteSubmission(int submissionID)
		{
			_submissionRepository.Delete(new Specification<Submission>(x => x.SubmissionID == submissionID));
		}
	}
}
