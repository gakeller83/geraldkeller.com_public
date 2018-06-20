using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace geraldkeller.com.Authentication
{
  public class TokenValidator
  {
    public TokenValidator()
    {

    }

    public bool ValidateToken(string token)
    {
      var handler = new JwtSecurityTokenHandler();
      SecurityToken securitytoken = new JwtSecurityToken();
      var parameters = new TokenValidationParameters();

      parameters.ValidIssuer = TokenIssuer.issuer;
      parameters.ValidAudience = TokenIssuer.audience;
      parameters.IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(TokenIssuer.secret));
      parameters.RequireSignedTokens = true;
     
      var principal = handler.ValidateToken(token, parameters, out securitytoken);

      return principal.Identity.IsAuthenticated;
    }
  }
}