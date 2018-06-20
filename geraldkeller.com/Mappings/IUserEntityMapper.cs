//Copyright Gerald Keller 2017

namespace geraldkeller.com.Mappings
{
  public interface IUserEntityMapper
  {
    Entities.User MapFromUserModel(Models.User user);
    Entities.User MapPasswordInfo(Entities.User user, DTOs.PasswordInfo passwordInfo);
  }
}