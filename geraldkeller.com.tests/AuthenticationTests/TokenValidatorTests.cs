using NUnit.Framework;
using geraldkeller.com.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace geraldkeller.com.tests.AuthenticationTests
{
  [TestFixture]
  public class TokenValidatorTests
  {
    [Test]
    public void GivenValidJwt_TokenValidatorValidatesToken_WhenValidateTokenIsCalled()
    {
      //Arrange
      var username = "ausername";
      var token = IssueMockToken(username, TokenIssuer.secret, TokenIssuer.issuer, TokenIssuer.audience);
      var sut = new TokenValidator();

      //Act
      var result = sut.ValidateToken(token);

      //Assert
      Assert.IsTrue(result);
    }

    [Test]
    public void GivenInvalidJwtSignatureKey_TokenValidatorInvalidatesToken_WhenValidateTokenIsCalled()
    {
      //Arrange
      var username = "ausername";
      var secret = "2zvt1RepX+UoV4xo0LjD2+vw0ABCDEFGNRITo8jW23cTlHn9uPXQWvgRPISmmv27f01G39mfAf/lzUVTnt4qbQ==";
      var token = IssueMockToken(username, secret, TokenIssuer.issuer, TokenIssuer.audience);
      var sut = new TokenValidator();

      //Act & Assert
      Assert.Throws<SecurityTokenInvalidSignatureException>(() => sut.ValidateToken(token));
    }

    [Test]
    public void GivenInvalidJwtAudience_TokenValidatorInvalidatesToken_WhenValidateTokenIsCalled()
    {
      //Arrange
      var username = "ausername";
      var audience = "someaudience";
      var token = IssueMockToken(username, TokenIssuer.secret, TokenIssuer.issuer, audience);
      var sut = new TokenValidator();

      //Act & Assert
      Assert.Throws<SecurityTokenInvalidAudienceException>(() => sut.ValidateToken(token));
    }

    [Test]
    public void GivenInvalidJwtIssuer_TokenValidatorInvalidatesToken_WhenValidateTokenIsCalled()
    {
      //Arrange
      var username = "ausername";
      var issuer = "someissuer";
      var token = IssueMockToken(username, TokenIssuer.secret, issuer, TokenIssuer.audience);
      var sut = new TokenValidator();

      //Act & Assert
      Assert.Throws<SecurityTokenInvalidIssuerException>(() => sut.ValidateToken(token));
    }

    public string IssueMockToken(string username, string secret, string issuer, string audience)
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
