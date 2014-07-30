using System.Collections.Generic;
using Online_Judge.DAL.Entities;

namespace Online_Judge.BLL
{
	/// <summary>
	/// IProblemService interface
	/// </summary>
	public interface IProblemService
	{
		Problem GetProblem(int id);

		IEnumerable<Problem> GetAll();
 
		void AddProblem(Problem problem);

		void Delete(int problemId);
	}
}
