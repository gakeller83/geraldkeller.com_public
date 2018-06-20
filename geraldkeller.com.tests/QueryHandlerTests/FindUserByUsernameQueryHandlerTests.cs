//Copyright Gerald Keller 2017

using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using geraldkeller.com.Queries;
using geraldkeller.com.Mappings;
using geraldkeller.com.QueryHandlers;
using System.Collections.Generic;
using System.Linq;

namespace geraldkeller.com.tests.QueryHandlerTests
{
  [TestFixture]
  public class FindUserByUsernameQueryHandlerTests
  {
    [Test]
    public async Task GivenUserModel_MapsToUserEntityAndExecutesQuery_WhenHandleIsCalled()
    {
      //arrange
      var userModel = new Models.User();
      var userEntity = new Entities.User { username = "username" };
      var list = new List<Entities.User> { userEntity };

      var mapper = new Mock<IUserEntityMapper>();
      mapper.Setup(m => m.MapFromUserModel(It.IsAny<Models.User>())).Returns(userEntity);

      var query = new Mock<IFindUserByUsernameQuery>();
      query.Setup(q => q.execute(It.IsAny<Entities.User>())).ReturnsAsync(list);

      var sut = new FindUserByUsernameQueryHandler(query.Object, mapper.Object);

      //act
      var result = await sut.handle(userModel);

      //assert
      mapper.Verify(m => m.MapFromUserModel(It.Is<Models.User>(u => u.username == userModel.username)), Times.Once());
      query.Verify(q => q.execute(It.Is<Entities.User>(u => u.username == userEntity.username)), Times.Once());
      Assert.AreEqual(list.Count, result.Count);
      Assert.AreEqual(list.FirstOrDefault().username, result.FirstOrDefault().username);
    }
  }
}
