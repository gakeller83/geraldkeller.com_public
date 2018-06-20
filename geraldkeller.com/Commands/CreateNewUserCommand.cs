//Copyright Gerald Keller 2017
using geraldkeller.com.DBContexts;
using geraldkeller.com.Entities;
using System.Threading.Tasks;

namespace geraldkeller.com.Commands
{
  public class CreateNewUserCommand: ICreateNewUserCommand
  {
    private IMySqlContext context;

    public CreateNewUserCommand(IMySqlContext context)
    {
      this.context = context;
    }

    async public Task<bool> execute(User user)
    {
      using (context)
      {
        context.User.Add(user);
        await context.SaveChangesAsync();
        return true;        
      }
    }
  }
}