//Copyright Gerald Keller 2017
using System.Threading.Tasks;
using geraldkeller.com.Queries;
using geraldkeller.com.Mappings;
using System.Collections.Generic;

namespace geraldkeller.com.QueryHandlers
{
  public class FindUserByUsernameQueryHandler : IFindUserByUsernameQueryHandler
  {
    private IFindUserByUsernameQuery query;
    private IUserEntityMapper mapper;

    public FindUserByUsernameQueryHandler(IFindUserByUsernameQuery query, IUserEntityMapper mapper)
    {
      this.query = query;
      this.mapper = mapper;
    }

    async public Task<List<Entities.User>> handle(Models.User userModel)
    {
      var userEntity = mapper.MapFromUserModel(userModel);

      var result = await query.execute(userEntity);

      return result;
    }
  }
}