using System.Collections.Generic;
using Online_Judge.DAL;
using Online_Judge.DAL.Entities;
using System.Linq;
using Online_Judge.DAL.Specification;

namespace Online_Judge.BLL.Impl
{
	/// <summary>
	/// ProblemService class
	/// </summary>
	public class ProblemService : IProblemService
	{
		#region Dependencies

		private readonly IRepository _problemRepository;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="ProblemService"/> class.
		/// </summary>
		/// <param name="problemRepository">The problem repository.</param>
		public ProblemService(IRepository problemRepository)
		{
			_problemRepository = problemRepository;
		}

		#endregion

		#region IProblemService Members

		public Problem GetProblem(int id)
		{
			return _problemRepository.SingleOrDefault(new Specification<Problem>(x => x.ProblemID == id));
		}

		public IEnumerable<Problem> GetAll()
		{
			return _problemRepository.GetAll<Problem>().ToList();
		}

		public void AddProblem(Problem problem)
		{
			_problemRepository.Add(problem);
		}

		public void Delete(int problemId)
		{
			_problemRepository.Delete(new Specification<Problem>(x => x.ProblemID == problemId));
		}

		#endregion
	}
}