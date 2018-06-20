using NUnit.Framework;
using geraldkeller.com.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;

namespace geraldkeller.com.tests.AuthenticationTests
{
  [TestFixture]
  public class TokenIssuerTests
  {
    [Test]
    public void GivenUsername_TokenIssuerCreatesToken_WhenIssueTokenIsCalled()
    {
      //Arrange
      var username = "ausername";
      var sut = new TokenIssuer();

      //Act
      var token = sut.IssueToken(username);
      var reader = new JwtSecurityTokenHandler();
      var securitytoken = reader.ReadJwtToken(token);

      //Assert
      Assert.AreEqual(securitytoken.Claims.Where(c => c.Type == "aud").FirstOrDefault().Value, TokenIssuer.audience);
      Assert.AreEqual(securitytoken.Claims.Where(c => c.Type == "iss").FirstOrDefault().Value, TokenIssuer.issuer);
      Assert.AreEqual(securitytoken.Claims.Where(c => c.Type == "unique_name").FirstOrDefault().Value, username);
    }
  }
}
