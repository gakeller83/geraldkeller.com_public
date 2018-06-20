//Copyright Gerald Keller 2017
using System.Threading.Tasks;

namespace geraldkeller.com.Commands
{
  public interface ICreateNewUserCommand
  {
    Task<bool> execute(Entities.User user);
  }
}