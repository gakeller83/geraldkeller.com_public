using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace geraldkeller.com.Authentication
{
  public class TokenIssuer
  {
    public const string secret = "oxsscEPMachlZkVb6KR+J/LvBj6hXt7WiAQhjG35dC/AT+8/Obsnw971ElvtIAJDu/PHmvLy5tOb3LS/mkl/xg==";
    public const string issuer = "https://geraldkeller.com";
    public const string audience = "https://www.geraldkeller.com";

    public TokenIssuer()
    {

    }

    public string IssueToken(string username)
    {
      var key = Convert.FromBase64String(secret);
      var tokenHandler = new JwtSecurityTokenHandler();

      var descriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new List<Claim>
          {new Claim(ClaimTypes.Name, username)}),
        Expires = DateTime.UtcNow.AddMinutes(120),
        SigningCredentials =
          new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Issuer = issuer,
        Audience = audience
      };

      var stoken = tokenHandler.CreateToken(descriptor);
      var token = tokenHandler.WriteToken(stoken);

      return token;
    }
  }
}