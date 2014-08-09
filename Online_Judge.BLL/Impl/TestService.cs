using System;
using Online_Judge.DAL;
using Online_Judge.DAL.Entities;
using Online_Judge.DAL.Specification;

namespace Online_Judge.BLL.Impl
{
	/// <summary>
	/// TestService class
	/// </summary>
	public class TestService : ITestService
	{
		#region Dependencies

		private readonly IRepository _testRepository;

		#endregion

		#region Constructor

		public TestService(IRepository testRepository)
		{
			_testRepository = testRepository;
		}

		#endregion

		#region ITestService Members

		public Test GetTest(int testID)
		{
			return _testRepository.SingleOrDefault(new Specification<Test>(x => x.TestID == testID));
		}

		public void CreateTest(Test test)
		{
			_testRepository.Add(test);

			_testRepository.UnitOfWork.SaveChanges();
		}

		public void UpdateTest(Test test)
		{
			var existingTest = _testRepository.SingleOrDefault(new Specification<Test>(x => x.TestID == test.TestID));

			if (existingTest == null)
			{
				throw new InvalidOperationException(string.Format("Test of id {0} does not exist", test.TestID));
			}

			existingTest.Name = test.Name;
			existingTest.TimeLimit = test.TimeLimit;
			existingTest.ProblemID = test.ProblemID;
			existingTest.UpdateTS = DateTime.Now;

			_testRepository.UnitOfWork.SaveChanges();
		}

		public void DeleteTest(int testID)
		{
			_testRepository.Delete(new Specification<Test>(x => x.TestID == testID));

			_testRepository.UnitOfWork.SaveChanges();
		}

		#endregion
	}
}