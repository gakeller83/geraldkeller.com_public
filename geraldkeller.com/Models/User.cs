//Copyright Gerald Keller 2017
using Newtonsoft.Json;

namespace geraldkeller.com.Models
{
  [JsonObject]
  public class User
  {
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
  }
}