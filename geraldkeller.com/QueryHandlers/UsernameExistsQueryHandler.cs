//Copyright Gerald Keller 2017

using System.Threading.Tasks;

namespace geraldkeller.com.QueryHandlers
{
  public class UsernameExistsQueryHandler: IUsernameExistsQueryHandler
  {
    private IFindUserByUsernameQueryHandler findUserHandler;

    public UsernameExistsQueryHandler(IFindUserByUsernameQueryHandler findUserHandler)
    {
      this.findUserHandler = findUserHandler;
    }

    async public Task<bool> handle(Models.User user)
    {
      var users = await findUserHandler.handle(user);
      return (users.Count > 0);
    }
  }
}