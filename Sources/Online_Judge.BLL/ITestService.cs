using Online_Judge.DAL.Entities;

namespace Online_Judge.BLL
{
	/// <summary>
	/// ITestService interface
	/// </summary>
	public interface ITestService
	{
		Test GetTest(int testID);

		void CreateTest(Test test);

		void UpdateTest(Test test);

		void DeleteTest(int testID);
	}
}
