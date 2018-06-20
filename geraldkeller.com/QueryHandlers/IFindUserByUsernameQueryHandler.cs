//Copyright Gerald Keller 2017

using System.Collections.Generic;
using System.Threading.Tasks;

namespace geraldkeller.com.QueryHandlers
{
  public interface IFindUserByUsernameQueryHandler
  {
    Task<List<Entities.User>> handle(Models.User user);
  }
}
