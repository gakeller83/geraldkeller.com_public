//Copyright Gerald Keller 2017

using System.Collections.Generic;
using System.Threading.Tasks;

namespace geraldkeller.com.Queries
{
  public interface IFindUserByUsernameQuery
  {
    Task<List<Entities.User>> execute(Entities.User user);
  }
}
