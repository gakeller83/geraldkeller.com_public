//Copyright Gerald Keller 2017
using System.Web.Mvc;
using geraldkeller.com.Models;
using geraldkeller.com.CommandHandlers;
using geraldkeller.com.QueryHandlers;
using System.Threading.Tasks;
using geraldkeller.com.App_Start;
using Microsoft.Practices.Unity;
using System.Net;

namespace geraldkeller.com.Controllers
{
  public class UserController : Controller
  {
    // GET api/<controller>
    async public Task<ActionResult> Create(User user)
    {
      var container = UnityConfig.GetConfiguredContainer();
      var userExistsQueryHandler = container.Resolve<IUsernameExistsQueryHandler>();

      if (!await userExistsQueryHandler.handle(user))
      {
        var createUserCommandHandler = container.Resolve<ICreateNewUserCommandHandler>();
        var result = await createUserCommandHandler.handle(user);
        
        return Json("User created");
      }
      else
      {
        Response.StatusCode = (int)HttpStatusCode.Conflict;
        return Json("User already exists. Please choose different username");
      };
    }
  }
}