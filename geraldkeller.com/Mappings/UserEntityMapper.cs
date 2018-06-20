//Copyright Gerald Keller 2017

namespace geraldkeller.com.Mappings
{
  public class UserEntityMapper : IUserEntityMapper
  {
    public UserEntityMapper()
    {
      
    }

    public Entities.User MapFromUserModel(Models.User user)
    {
      return new Entities.User
      {
        username = user.username,
        userinfo = new Entities.UserInfo
        {
          email = user.email    
        }
        
      };
    }

    public Entities.User MapPasswordInfo(Entities.User user, DTOs.PasswordInfo passwordInfo)
    {
      user.pwhash = passwordInfo.hash;
      user.salt = passwordInfo.salt;

      return user;
    }
  }
}