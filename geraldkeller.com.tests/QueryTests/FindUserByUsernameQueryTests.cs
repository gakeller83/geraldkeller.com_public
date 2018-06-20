//Copyright Gerald Keller 2017

using Moq;
using NUnit.Framework;
using geraldkeller.com.Entities;
using geraldkeller.com.DBContexts;
using geraldkeller.com.tests.Doubles;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace geraldkeller.com.tests.QueryTests
{
  [TestFixture]
  public class FindUserByUsernameQueryTests
  {
    private IQueryable<User> data;
    private Mock<DbSet<User>> userSet;
    private Mock<IMySqlContext> context;

    [SetUp]
    public void SetupTest()
    {
      data = new List<User>
      {
        new User {id = 1, username = "user1"},
        new User {id = 2, username = "user2" },
        new User {id = 3, username = "user3" }
      }.AsQueryable();

      userSet = new Mock<DbSet<User>>();
      userSet.As<IDbAsyncEnumerable<User>>()
        .Setup(u => u.GetAsyncEnumerator())
        .Returns(new TestDbAsyncEnumerator<User>(data.GetEnumerator()));

      userSet.As<IQueryable<User>>()
        .Setup(u => u.Provider)
        .Returns(new TestDbAsyncQueryProvider<User>(data.Provider));

      userSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
      userSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
      userSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      context = new Mock<IMySqlContext>();
      context.Setup(c => c.User).Returns(userSet.Object);
    }
    [Test]
    public async Task GivenUserEntity_FindsUserWithMatchingUsername_WhenExecuteIsCalledAndUserExists()
    {
      //arrange
      var user = new User { username = "user1" };
      var sut = new Queries.FindUserByUsernameQuery(context.Object);

      //act
      var result = await sut.execute(user);

      //arrange
      Assert.AreEqual(result.Count, 1);
      Assert.AreEqual(result.FirstOrDefault().username, "user1");
    }

    [Test]
    public async Task GivenUserEntity_FindsNoUserWithMatchingUsername_WhenExecuteIsCalledAndUserDoesNotExist()
    {
      //arrange
      var user = new User { username = "user4" };
      var sut = new Queries.FindUserByUsernameQuery(context.Object);

      //act
      var result = await sut.execute(user);

      //arrange
      Assert.AreEqual(result.Count, 0);
    }
  }
}
