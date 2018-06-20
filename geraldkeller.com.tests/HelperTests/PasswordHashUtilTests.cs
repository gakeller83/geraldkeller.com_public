//Copyright Gerald Keller 2017

using NUnit.Framework;

namespace geraldkeller.com.tests.HelperTests
{
  [TestFixture]
  public class PasswordHashUtilTests
  {
    [Test]
    public void GivenPasswordString_PasswordInfoWithHashAndSaltIsGenerated_WhenGeneratePasswordInfoIsCalled()
    {
      //arrange
      var password = "apassword";
      var sut = new Helpers.PasswordHashUtil();
      //act
      var pwinfo = sut.GeneratePasswordInfo(password);
      //assert
      Assert.IsTrue(pwinfo.hash.Length > 0);
      Assert.IsTrue(pwinfo.salt.Length > 0);
    }
  }
}
