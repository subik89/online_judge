using System.Collections.Generic;
using Online_Judge.DAL.Entities;

namespace Online_Judge.BLL
{
	/// <summary>
	/// ISubmissionService interface
	/// </summary>
	public interface ISubmissionService
	{
		IEnumerable<Submission> GetSubmissions(int userID);
			
		Submission GetSubmission(int submissionID);

		void AddSubmission(Submission submission);

		void UpdateSubmission(Submission submission);

		void DeleteSubmission(int submissionID);
	}
}
