using System.IO;
using System.Threading.Tasks;
using geraldkeller.com.DTOs;

namespace geraldkeller.com.QueryHandlers
{
  public class GetResumeQueryHandler : IGetResumeQueryHandler
  {
    const string RESUME_RESOURCE = "geraldkeller.com.Resources.Keller_Gerald_Resume_Web.html";

    public GetResumeQueryHandler()
    {

    }

    public ResumeDto handle()
    {
      var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(RESUME_RESOURCE);
      var sr = new StreamReader(stream);
      
      return new ResumeDto { value = sr.ReadToEnd() };  
    }
  }
}