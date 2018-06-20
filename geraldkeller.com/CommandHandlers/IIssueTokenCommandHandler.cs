using System.Web.Mvc;
using geraldkeller.com.DTOs;

namespace geraldkeller.com.CommandHandlers
{
  public interface IIssueTokenCommandHandler
  {
     JsonToken handle(string username);
  }
}
