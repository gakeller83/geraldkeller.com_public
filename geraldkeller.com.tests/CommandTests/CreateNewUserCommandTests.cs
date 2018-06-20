//Copyright Gerald Keller 2017

using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace geraldkeller.com.tests.CommandTests
{
  [TestFixture]
  public class CreateNewUserCommandTests
  {
    [Test]
    public async Task GivenUserEntity_CreateNewUserCommandAddsUserToContextOnce_AndCallsSaveChangesAsyncOnce_WhenExecuteIsCalled()
    {
      //arrange
      var context = new Mock<DBContexts.IMySqlContext>();
      var dbset = new Mock<DbSet<Entities.User>>();
      context.SetupProperty(c => c.User, dbset.Object);
      var user = new Entities.User { username = "username" };
      
      var sut = new Commands.CreateNewUserCommand(context.Object);
      
      //act
      await sut.execute(user);

      //assert
      dbset.Verify(d => d.Add(It.Is<Entities.User>(u => u.username == user.username)), Times.Once());
      context.Verify(c => c.SaveChangesAsync(), Times.Once);
    }
  }
}