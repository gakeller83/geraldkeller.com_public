using Newtonsoft.Json;
using System;
namespace geraldkeller.com.DTOs
{
  [JsonObject]
  public class JsonToken
  {
    [JsonProperty]
    public string token { get; set; }
    public string username { get; set; }
    public DateTime expires { get; set; }

    public JsonToken()
    {
    }
  }
}