//Copyright Gerald Keller 2017
using System.Threading.Tasks;
using System.Data.Entity;
using geraldkeller.com.Entities;
using System.Linq;
using System.Collections.Generic;
using geraldkeller.com.DBContexts;

namespace geraldkeller.com.Queries
{
  public class FindUserByUsernameQuery : IFindUserByUsernameQuery
  {
    private IMySqlContext context;

    public FindUserByUsernameQuery(IMySqlContext context)
    {
      this.context = context;
    }

    async public Task<List<User>> execute(User user)
    {
      using (context)
      {
        var query = await context.User.AsQueryable().Where(u => u.username == user.username).ToListAsync();
        
        return query;
      }
    }
  }
}