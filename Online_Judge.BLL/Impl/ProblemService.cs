using Online_Judge.DAL;
using Online_Judge.DAL.Entities;

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

		public void AddProblem(Problem problem)
		{
			_problemRepository.Add(problem);
		}

		#endregion
	}
}