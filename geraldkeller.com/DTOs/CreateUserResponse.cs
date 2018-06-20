//Copyright Gerald Keller 2017
using System;

namespace geraldkeller.com.DTOs
{
  public class CreateUserResponse
  {
    public bool success { get; set; }
    public Guid token { get; set; }
    public string message { get; set; }
  }
}