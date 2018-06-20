//Copyright Gerald Keller 2017

using NUnit.Framework;

namespace geraldkeller.com.tests.MappingTests
{
  [TestFixture]
  public class UserEntityMapperTests
  {
    [Test]
    public void GivenUserModel_MapFromUserModelCorrectlyMapsToUserEntityClass_WhenCalled()
    {
      //arrange
      var userModel = new Models.User
      {
        username = "username",
        email = "email",
        password = "password"
      };

      var sut = new Mappings.UserEntityMapper();

      //act
      var userEntity = sut.MapFromUserModel(userModel);

      //assert
      Assert.AreEqual(userEntity.username, userModel.username);
      Assert.AreEqual(userEntity.userinfo.email, userModel.email);
    }

    [Test]
    public void GivenUserEntityAndPasswordInfo_MapPasswordInfoCorrectlyMapsPasswordInfoToUserEntity_WhenCalled()
    {
      //arrange
      var passwordInfo = new DTOs.PasswordInfo
      {
        salt = "salt"
      };
      var crypto = new System.Security.Cryptography.SHA512Managed();
      passwordInfo.hash = crypto.ComputeHash(System.Text.Encoding.ASCII.GetBytes("apassword"));

      var userInfo = new Entities.UserInfo
      {
        email = "anemail",
        id = 1
      };
      var userEntity = new Entities.User
      {
        id = 1,
        userinfo = userInfo,
        username = "username"
      };

      var sut = new Mappings.UserEntityMapper();

      //act
      userEntity = sut.MapPasswordInfo(userEntity, passwordInfo);

      //assert
      Assert.AreEqual(userEntity.username, "username");
      Assert.AreEqual(userEntity.id, 1);
      Assert.AreEqual(userEntity.pwhash, passwordInfo.hash);
      Assert.AreEqual(userEntity.salt, passwordInfo.salt);
      Assert.AreEqual(userEntity.userinfo.email, "anemail");
      Assert.AreEqual(userEntity.userinfo.id, 1);
    }
  }
}
