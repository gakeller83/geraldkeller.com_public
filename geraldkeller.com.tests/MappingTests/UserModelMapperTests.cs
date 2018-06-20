//Copyright Gerald Keller 2017

using NUnit.Framework;

namespace geraldkeller.com.tests.MappingTests
{
  [TestFixture]
  public class UserModelMapperTests
  {
    [Test]
    public void GivenUserEntity_CorrectlyMapsDataToUserModel_WhenMapFromUserEntityIsCalled()
    {
      //arrange
      var userEntity = new Entities.User
      {
        username = "username",
        userinfo = new Entities.UserInfo
        {
          email = "email"
        }
      };

      var sut = new Mappings.UserModelMapper();

      //act
      var userModel = sut.MapFromUserEntity(userEntity);

      //assert
      Assert.AreEqual(userModel.email, userEntity.userinfo.email);
      Assert.AreEqual(userModel.username, userEntity.username);
    }
  }
}
