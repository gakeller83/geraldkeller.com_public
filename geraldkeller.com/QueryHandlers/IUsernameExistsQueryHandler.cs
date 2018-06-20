//Copyright Gerald Keller 2017

using System.Threading.Tasks;

namespace geraldkeller.com.QueryHandlers
{
  public interface IUsernameExistsQueryHandler
  {
    Task<bool> handle(Models.User user);
  }
}
