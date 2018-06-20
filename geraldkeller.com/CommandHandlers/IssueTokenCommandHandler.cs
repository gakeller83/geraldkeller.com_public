
using geraldkeller.com.Commands;
using geraldkeller.com.Mappings;
using geraldkeller.com.DTOs;
namespace geraldkeller.com.CommandHandlers
{
  public class IssueTokenCommandHandler : IIssueTokenCommandHandler
  {
    public IIssueTokenCommand command;
    public IJsonTokenDtoMapper mapper;

    public IssueTokenCommandHandler(IIssueTokenCommand command, IJsonTokenDtoMapper mapper)
    {
      this.command = command;
      this.mapper = mapper;
    }

    public JsonToken handle(string username)
    {
      var token = command.execute(username);
      var tokenDto = mapper.map(username, token);
      return tokenDto;

    }
  }
}