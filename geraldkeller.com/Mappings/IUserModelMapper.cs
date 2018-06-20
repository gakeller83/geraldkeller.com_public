//Copyright Gerald Keller 2017

namespace geraldkeller.com.Mappings
{
  public interface IUserModelMapper
  {
    Models.User MapFromUserEntity(Entities.User user);
  }
}
