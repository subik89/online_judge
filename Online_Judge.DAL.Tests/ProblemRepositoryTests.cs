using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Online_Judge.DAL.Entities;

namespace Online_Judge.DAL.Tests
{
	/// <summary>
	/// ProblemRepositoryTests class
	/// </summary>
	[TestClass]
	public class ProblemRepositoryTests : TestsBase
	{
		[TestMethod]
		public void GetAllTest()
		{
			// Arrange
			Builder<Problem>.CreateListOfSize(2).Persist();

			var problemRepository = new GenericRepository(Context);
			problemRepository.UnitOfWork.SaveChanges();

			// Act
			var result = problemRepository.GetAll<Problem>();

			// Assert
		}
	}
}
