//Copyright Gerald Keller 2017
using geraldkeller.com.DTOs;
using System;
using System.Security.Cryptography;

namespace geraldkeller.com.Helpers
{
  public class PasswordHashUtil : IPasswordHashUtil
  {
    public PasswordHashUtil() { }

    public PasswordInfo GeneratePasswordInfo(string password)
    {
      var passwordInfo = new PasswordInfo();
      passwordInfo.salt = GenerateSalt();
      var crypto = new SHA512Managed();
      passwordInfo.hash = crypto.ComputeHash(System.Text.Encoding.ASCII.GetBytes(passwordInfo.salt + password));
      return passwordInfo;
    }

    private string GenerateSalt()
    {
      var bytes = new byte[64];
      var crypto = new RNGCryptoServiceProvider();
      crypto.GetBytes(bytes);
      return Convert.ToBase64String(bytes);
    }
  }
}