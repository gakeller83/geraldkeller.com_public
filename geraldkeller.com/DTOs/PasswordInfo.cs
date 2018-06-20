//Copyright Gerald Keller 2017

namespace geraldkeller.com.DTOs
{
  public class PasswordInfo
  {
    public string salt {get;set;}
    public byte[] hash { get; set; }
  }
}