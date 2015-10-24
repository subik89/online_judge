using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Online_Judge.DAL.Entities;
using System.Linq;
using Online_Judge.DAL.Specification;

namespace Online_Judge.DAL.Tests
{
	/// <summary>
	/// UserRepositoryTests class
	/// </summary>
	[TestClass]
	public class UserRepositoryTests : TestsBase
	{
		private IRepository _userRepository;
		private IRepository UserRepository
		{
			get { return _userRepository ?? (_userRepository = new GenericRepository(Context)); }
			}

		[TestMethod]
		public void GetAllTest()
		{
			// Arrange
			var users = Builder<User>.CreateListOfSize(2).Persist();

			UserRepository.UnitOfWork.SaveChanges();

			// Act
			var result = UserRepository.GetAll<User>().ToList();

			// Assert
			Assert.IsNotNull(result);
			
			Assert.AreEqual(2, result.Count);
			for (int i = 0; i < result.Count; i++)
			{
				Assert.AreEqual(users[i].Email, result[i].Email);
				Assert.AreEqual(users[i].FirstName, result[i].FirstName);
				Assert.AreEqual(users[i].LastName, result[i].LastName);
				Assert.AreEqual(users[i].Password, result[i].Password);
			}
		}

		[TestMethod]
		public void SingleOrDefaultTest()
		{
			const string email = "a1@test.com";

			// Arrange
			Builder<User>.CreateListOfSize(10).Random(1).With(x => x.Email = email).Persist();

			UserRepository.UnitOfWork.SaveChanges();

			// Act
			var result = UserRepository.SingleOrDefault(new Specification<User>(x => x.Email.Equals(email)));

			// Assert
			Assert.IsNotNull(result);

			Assert.AreEqual(email, result.Email);
		}

		[TestMethod]
		public void AddEntitiesTest()
		{
			// Arrange
			var users = Builder<User>.CreateListOfSize(20).Build().ToList();

			// Act
			UserRepository.Add(users);
			UserRepository.UnitOfWork.SaveChanges();

			var dbUsers = UserRepository.GetAll<User>().ToList();

			// Assert
			Assert.IsNotNull(dbUsers);

			Assert.AreEqual(users.Count, dbUsers.Count);
			CollectionAssert.AreEqual(users, dbUsers);
		}

		[TestMethod]
		public void DeleteTest()
		{
			// Arrange
			var user = Builder<User>.CreateNew().Persist();
			
			UserRepository.UnitOfWork.SaveChanges();

			var specification = new Specification<User>(x => x.Email.Equals(user.Email));

			// Act
			UserRepository.Delete(specification);
			UserRepository.UnitOfWork.SaveChanges();

			// Assert
			var result = UserRepository.SingleOrDefault(specification);
			Assert.IsNull(result);
		}
	}
}
