using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geraldkeller.com.Commands
{
  public interface IIssueTokenCommand
  {
    string execute(string username);
  }
}
