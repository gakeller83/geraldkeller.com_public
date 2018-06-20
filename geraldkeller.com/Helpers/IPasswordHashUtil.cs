//Copyright Gerald Keller 2017

namespace geraldkeller.com.Helpers
{
  public interface IPasswordHashUtil
  {
    DTOs.PasswordInfo GeneratePasswordInfo(string password);
  }
}