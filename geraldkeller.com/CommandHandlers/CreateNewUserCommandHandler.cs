//Copyright Gerald Keller 2017
using System.Threading.Tasks;
using geraldkeller.com.Commands;

namespace geraldkeller.com.CommandHandlers
{
  public class CreateNewUserCommandHandler : ICreateNewUserCommandHandler
  {
    private Helpers.IPasswordHashUtil passwordHash;
    private Mappings.IUserEntityMapper entityMapper;
    private ICreateNewUserCommand command;

    public CreateNewUserCommandHandler(ICreateNewUserCommand command, Helpers.IPasswordHashUtil passwordHash,
      Mappings.IUserEntityMapper entityMapper)
    {
      this.command = command;
      this.passwordHash = passwordHash;
      this.entityMapper = entityMapper;
    }

    async public Task<bool> handle(Models.User user)
    {
      var userEntity = entityMapper.MapFromUserModel(user);

      var passwordInfo = passwordHash.GeneratePasswordInfo(user.password);

      userEntity = entityMapper.MapPasswordInfo(userEntity, passwordInfo);

      var result = await command.execute(userEntity);
      return result;
    }
  }
}