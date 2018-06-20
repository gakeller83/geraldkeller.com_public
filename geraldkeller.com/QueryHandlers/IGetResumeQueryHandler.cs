using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using geraldkeller.com.DTOs;

namespace geraldkeller.com.QueryHandlers
{
  public interface IGetResumeQueryHandler
  {
    ResumeDto handle();
  }
}
