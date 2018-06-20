using geraldkeller.com.DTOs;

namespace geraldkeller.com.Mappings
{
  public interface IJsonTokenDtoMapper
  {
    JsonToken map(string user, string token);
  }
}
