//Copyright Gerald Keller 2017

namespace geraldkeller.com.Mappings
{
  public class UserModelMapper : IUserModelMapper
  {
    public UserModelMapper()
    {

    }

    public Models.User MapFromUserEntity(Entities.User user)
    {
      return new Models.User
      {
        email = user.userinfo.email,
        username = user.username
      };
    }
  }
}