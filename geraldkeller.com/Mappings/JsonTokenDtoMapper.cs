using System;
using geraldkeller.com.DTOs;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace geraldkeller.com.Mappings
{
  public class JsonTokenDtoMapper: IJsonTokenDtoMapper
  {
    public JsonToken map(string username, string token)
    {
      var reader = new JwtSecurityTokenHandler();
      var stoken = reader.ReadToken(token);
      var expires = stoken.ValidTo;
      var dto = new JsonToken { username = username, token = token, expires = expires };

      return dto;
    }
  }
}