//Copyright Gerald Keller 2017

using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace geraldkeller.com.tests.CommandHandlerTests
{
  [TestFixture]
  public class CreateNewUserCommandHandlerTests
  {
    [Test]
    public async Task GivenUserModel_CreateNewUserCommandHandlerConvertsUserModelToEntity_ThenGeneratesAndMapsPasswordInfo_ThenCallsExecuteOnCommand_WhenHandleIsCalled()
    {
      //arrange
      var command = new Mock<Commands.ICreateNewUserCommand>();
      var hashutil = new Mock<Helpers.IPasswordHashUtil>();
      var entityMapper = new Mock<Mappings.IUserEntityMapper>();

      var passwordinfo = new DTOs.PasswordInfo { salt = "salt" };
      var userEntity = new Entities.User { username = "username"};
      var userModel = new Models.User { username = "username", password = "password" };

      command.Setup(c => c.execute(It.IsAny<Entities.User>())).ReturnsAsync(true);
      hashutil.Setup(h => h.GeneratePasswordInfo(It.IsAny<string>())).Returns(passwordinfo);
      entityMapper.Setup(m => m.MapFromUserModel(It.IsAny<Models.User>())).Returns(userEntity);
      entityMapper.Setup(m => m.MapPasswordInfo(It.IsAny<Entities.User>(), It.IsAny<DTOs.PasswordInfo>())).Returns(userEntity);
      var sut = new CommandHandlers.CreateNewUserCommandHandler(command.Object,hashutil.Object, entityMapper.Object);

      //act
      await sut.handle(userModel);

      //assert
      entityMapper.Verify(f => f.MapFromUserModel(It.Is<Models.User>(u => u.username == userModel.username)), Times.Once());
      entityMapper.Verify(f => f.MapPasswordInfo(It.Is<Entities.User>(u => u.username == userEntity.username), It.Is<DTOs.PasswordInfo>(pi => pi.salt == passwordinfo.salt)),Times.Once());
      hashutil.Verify(h => h.GeneratePasswordInfo(It.Is<string>(s => s == userModel.password)), Times.Once());
      command.Verify(c => c.execute(It.Is<Entities.User>(u => u.username == userEntity.username)), Times.Once());
    }
  }
}
