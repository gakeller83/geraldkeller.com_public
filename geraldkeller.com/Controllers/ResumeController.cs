//Copyright Gerald Keller 2017
using System.Web.Mvc;

using geraldkeller.com.App_Start;
using Microsoft.Practices.Unity;
using geraldkeller.com.QueryHandlers;

namespace geraldkeller.com.Controllers
{
  public class ResumeController : Controller
  {
    // GET: Resume
    [HttpGet]
    public ActionResult Get()
    {
      var container = UnityConfig.GetConfiguredContainer();
      var getResumeQueryHandler = container.Resolve<IGetResumeQueryHandler>();

      var resume = getResumeQueryHandler.handle();

      return Json(resume, JsonRequestBehavior.AllowGet);
    }
  }
}