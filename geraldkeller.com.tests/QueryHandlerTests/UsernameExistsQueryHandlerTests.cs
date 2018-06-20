//Copyright Gerald Keller 2017

using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using geraldkeller.com.QueryHandlers;
using System.Collections.Generic;


namespace geraldkeller.com.tests.QueryHandlerTests
{
  [TestFixture]
  public class UsernameExistsQueryHandlerTests
  {
    [Test]
    public async Task GivenUserModel_CallsFindUserByUsernameQueryHandlerAndReturnsTrue_WhenHandleIsCalledAndUserExists()
    {
      //Arrange
      var userModel = new Models.User { username = "username" };
      var list = new List<Entities.User>() { new Entities.User()};

      var handler = new Mock<IFindUserByUsernameQueryHandler>();
      handler.Setup(h => h.handle(It.IsAny<Models.User>())).ReturnsAsync(list);

      var sut = new UsernameExistsQueryHandler(handler.Object);

      //Act
      var result = await sut.handle(userModel);

      //Assert
      handler.Verify(h => h.handle(It.Is<Models.User>(u => u.username == userModel.username)), Times.Once());
      Assert.IsTrue(result);
    }

    [Test]
    public async Task GivenUserModel_CallsFindUserByUsernameQueryHandlerAndReturnsFalse_WhenHandleIsCalledAndUserDoesNotExist()
    {
      //Arrange
      var userModel = new Models.User { username = "username" };
      var list = new List<Entities.User>() {};

      var handler = new Mock<IFindUserByUsernameQueryHandler>();
      handler.Setup(h => h.handle(It.IsAny<Models.User>())).ReturnsAsync(list);

      var sut = new UsernameExistsQueryHandler(handler.Object);

      //Act
      var result = await sut.handle(userModel);

      //Assert
      handler.Verify(h => h.handle(It.Is<Models.User>(u => u.username == userModel.username)), Times.Once());
      Assert.IsFalse(result);
    }
  }
}
