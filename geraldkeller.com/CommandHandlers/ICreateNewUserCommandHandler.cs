//Copyright Gerald Keller 2017
using System.Threading.Tasks;

namespace geraldkeller.com.CommandHandlers
{
  public interface ICreateNewUserCommandHandler
  {
    Task<bool> handle(Models.User user);
  }
}